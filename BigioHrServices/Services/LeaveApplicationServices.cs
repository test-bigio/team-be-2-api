using System.Globalization;
using BigioHrServices.Db;
using BigioHrServices.Db.Entities;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.LeaveApplication;
using Microsoft.EntityFrameworkCore;
using BigioHrServices.Model;
using BigioHrServices.Model.Employee;
using Microsoft.IdentityModel.Tokens;

namespace BigioHrServices.Services
{
    public interface ILeaveApplicationService
    {
        public BaseResponse LeaveAdd(LeaveAddRequest request);
    }

    public class LeaveApplicationServices : ILeaveApplicationService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ApplicationDbContext _db;

        public LeaveApplicationServices(ApplicationDbContext db, 
                                        IEmployeeService employeeService)
        {
            _db = db;
            _employeeService = employeeService;
        }
        public BaseResponse LeaveAdd(LeaveAddRequest request)
        {
            //validate data employee
            var employee = _employeeService.GetEmployeeById(request.EmployeeId);
            if (employee == null)
            {
                return new BaseResponse(false, "No employee with ID " + request.EmployeeId);
            }

            //validate leave allowance
            if (employee.JatahCuti == 0)
            {
                return new BaseResponse(false, "There's no leave allowance are available");
            }

            //parse value leavedate
            DateOnly leaveDate;
            DateTime dt;
            try
            {
                dt = DateTime.Parse(request.LeaveDate);
                leaveDate = DateOnly.FromDateTime(dt);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BaseResponse(false,
                    "Wrong LeaveDate format, please use dd-MM-YYY, dd/MM/yyy, yyyy-MM-dd, or yyy/MM/dd");
            }

            //validate LeaveDate
            var leave = _db.Leave
                .Where(p => p.EmployeeId == request.EmployeeId && p.leaveDate == leaveDate)
                .AsNoTracking()
                .FirstOrDefault();
            if (leave != null)
            {
                return new BaseResponse(false, "There's a leave in that LeaveDate");
            }

            if (dt.CompareTo(DateTime.Today) < 0)
            {
                return new BaseResponse(false, "LeaveDate can't before current date");
            }

            //validate data delegation matrix
            var dataDelegation = _db.DelegationMatrix
                .Where(p => p.EmployeeId == request.EmployeeId)
                .OrderBy(p => p.Priority)
                .AsNoTracking()
                .ToList();
            DelegationMatrix delegationMatrix = new DelegationMatrix();
            if (dataDelegation.IsNullOrEmpty())
            {
                return new BaseResponse(false, "No delegation matrix data for employee ID " + request.EmployeeId);
            }

            //check delegation who's available
            for (int i = 0; i < dataDelegation.Count; i++)
            {
                var dataLeave = _db.Leave
                    .Where(p => p.DelegationMatrixId == dataDelegation[i].Id &&
                                p.leaveDate == DateOnly.FromDateTime(DateTime.Now))
                    .GroupBy(p => p.EmployeeId)
                    .Count();
                
                var employeeDelegate = _db.Employees.Find(dataDelegation[i].EmployeeBackupId);
                if (employeeDelegate != null && !employeeDelegate.IsOnLeave && (dataLeave < 2))
                {
                    delegationMatrix = dataDelegation[i];
                    delegationMatrix.Employee = employeeDelegate;
                    break;
                }
            }

            // return if no delegation available
            if (delegationMatrix.EmployeeId == null)
            {
                return new BaseResponse(false, "Can't apply for leave, because there's no backup that available");
            }

            //get data reviewer
            var position = _db.Position.Find(employee.PositionId);
            string reviewerId = string.Empty;
            var employeeReviewer = _db.Employees
                .Where(p => p.Position.Level == position.Level - 1 && !p.IsOnLeave)
                .AsNoTracking()
                .FirstOrDefault();
            if (position.Level == 1)
            {
                reviewerId = "System";
            }
            else if (employeeReviewer != null)
            {
                reviewerId = employeeReviewer.Id.ToString();
            }
            else
            {
                reviewerId = delegationMatrix.Employee.Id.ToString();
            }

            //save data to DB
            Leave newLeave = new Leave()
            {
                EmployeeId = request.EmployeeId,
                leaveDate = leaveDate,
                TaskDetail = request.TaskDetail,
                IsApprove = reviewerId == "System",
                DelegationMatrixId = delegationMatrix.Id,
                reviewedBy = reviewerId,
                reviewedDate = reviewerId == "System" ? DateTime.UtcNow : null,
                CreatedBy = request.EmployeeId

            };
            try
            {
                _db.Leave.Add(newLeave);
                _db.SaveChanges();
                employee.JatahCuti -= 1;
                _db.Employees.Update(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new BaseResponse(false, "Leave failed to save");
            }

            return new BaseResponse(true, "Leave successfully saved");
        }
    }
}