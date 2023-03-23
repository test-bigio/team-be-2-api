using BigioHrServices.Db;
using BigioHrServices.Db.Entities;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.DelegationMatrix;
using Microsoft.EntityFrameworkCore;

namespace BigioHrServices.Services
{
    public interface IDelegationMatrixService
    {
        public Pageable<DelegationMatrixResponse> GetList(DelegationMatrixRequest request);
        public List<DelegationMatrixResponse> GetByEmployeeId(long employeeId);
        public void DelegationMatrixAdd(DelegationMatrixAddRequest request);
        public void DelegationMatrixUpdate(long id, DelegationMatrixUpdateRequest request);
        public DelegationMatrix getById(long id);
    }
    
    public class DelegationMatrixServices : IDelegationMatrixService
    {
        private readonly ApplicationDbContext _db;
        private readonly IEmployeeService _employeeServices;

        public DelegationMatrixServices(ApplicationDbContext db, IEmployeeService employeeServices)
        {
            _db = db;
            _employeeServices = employeeServices;
        }
        
        public Pageable<DelegationMatrixResponse> GetList(DelegationMatrixRequest request)
        {
            var query = _db.DelegationMatrix
                .AsNoTracking()
                .AsQueryable();

            var data = query
                .Select(_delegationMatrix => new DelegationMatrixResponse
                {
                    Employee = _delegationMatrix.Employee,
                    EmployeeBackup = _delegationMatrix.EmployeeBackup,
                    priority = _delegationMatrix.Priority
                })
                .ToList();

            return new Pageable<DelegationMatrixResponse>(data, request.Page, request.PageSize);
        }

        public List<DelegationMatrixResponse> GetByEmployeeId(long employeeId)
        {
            var query = _db.DelegationMatrix
                .Where(dm => dm.Employee.Id == employeeId)
                .AsNoTracking()
                .AsQueryable();

            var data = query
                .Select(_delegationMatrix => new DelegationMatrixResponse()
                {
                    Employee = _delegationMatrix.Employee,
                    EmployeeBackup = _delegationMatrix.EmployeeBackup,
                    priority = _delegationMatrix.Priority
                })
                .ToList();

            return data;
        }

        public void DelegationMatrixAdd(DelegationMatrixAddRequest request)
        {
            var data = _db.DelegationMatrix
                .Where(dm => dm.Employee.Id == request.EmployeeId)
                .Count();

            if (data > 3) throw new Exception("Your delegation has 3 employees");

            if (request.EmployeeId == request.EmployeeBackupId)
                throw new Exception("Employee cannot be the same as employee backup");

            if (request.priority > 3 || request.priority < 1)
                throw new Exception("Priority can only be 1 to 3");
            
            try
            {
                _db.DelegationMatrix.Add(new DelegationMatrix
                {
                    Employee = _employeeServices.GetEmployeeById(request.EmployeeId),
                    EmployeeBackup = _employeeServices.GetEmployeeById(request.EmployeeBackupId),
                    Priority = request.priority
                });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add data");
            }
        }

        public void DelegationMatrixUpdate(long id, DelegationMatrixUpdateRequest request)
        {
            var data = _db.DelegationMatrix
                .Find(id);
            if (data == null) throw new Exception("ID not found");
            
            if (request.EmployeeId == request.EmployeeBackupId)
                throw new Exception("Employee cannot be the same as employee backup");
            
            if (request.priority > 3 || request.priority < 1)
                throw new Exception("Priority can only be 1 to 3");

            try
            {
                data.Priority = request.priority;
                data.EmployeeId = request.EmployeeId;
                data.EmployeeBackupId = request.EmployeeBackupId;

                _db.DelegationMatrix.Update(data);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add data");
            }
        }

        public DelegationMatrix getById(long id)
        {
            return _db.DelegationMatrix.Find(id);
        }
    }
}

