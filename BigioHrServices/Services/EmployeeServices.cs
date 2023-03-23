using BigioHrServices.Db;
using BigioHrServices.Db.Entities;
using BigioHrServices.Model;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Employee;
using Microsoft.EntityFrameworkCore;
using BigioHrServices.Model.Auth;
using BigioHrServices.Utilities;
using BigioHrServices.Constant;

namespace BigioHrServices.Services
{
    public interface IEmployeeService
    {
        public Pageable<EmployeeResponse> GetList(EmployeeSearchRequest request);
        public EmployeeLeaveResponse GetEmployeeLeaveByNik(string nik);
        public EmployeeLeaveResponse GetEmployeeLeaveById(int id);
        public Employee GetEmployeeByNIK(string nik);
        public Employee GetEmployeeById(long id);
        public AuthLoginResponse AuthenticateUser(string nik, string passworod);
        public BaseResponse UpdatePinSignature(string nik, string lastSignnature, string newSignature);
        public BaseResponse AddPinSignature(string nik, string newSignature);
        public BaseResponse ResetPassword(string nik, string password);
        public void EmployeeAdd(EmployeeAddRequest request);
        public void EmployeeUpdate(EmployeeUpdateRequest request);
        public void EmployeeDelete(string nik);
    }

    public class EmployeeServices : IEmployeeService
    {
        private readonly ApplicationDbContext _db;
        private IAuditLogService _auditLogService;

        public EmployeeServices(ApplicationDbContext db, IAuditLogService auditLogService)
        {
            _db = db;
            _auditLogService = auditLogService;
        }

        public EmployeeLeaveResponse GetEmployeeLeaveByNik(string nik)
        {
            var employee = GetEmployeeByNIK(nik);
            var leaves = _db.Leave
                .Where(p => p.EmployeeId == employee.Id)
                .ToList();

            return new EmployeeLeaveResponse
            {
                NIK = employee.NIK,
                Name = employee.Name,
                Sex = employee.Sex,
                JoinDate = employee.JoinDate,
                WorkLength = employee.WorkLength,
                PositionId = employee.PositionId,
                Position = employee.Position,
                IsActive = employee.IsActive,
                DigitalSignature = employee.DigitalSignature,
                Leaves = leaves,
            };
        }
        
        public EmployeeLeaveResponse GetEmployeeLeaveById(int id)
        {
            var employee = GetEmployeeById(id);
            var leaves = _db.Leave
                .Where(p => p.EmployeeId == employee.Id)
                .ToList();

            return new EmployeeLeaveResponse
            {
                NIK = employee.NIK,
                Name = employee.Name,
                Sex = employee.Sex,
                JoinDate = employee.JoinDate,
                WorkLength = employee.WorkLength,
                PositionId = employee.PositionId,
                Position = employee.Position,
                IsActive = employee.IsActive,
                DigitalSignature = employee.DigitalSignature,
                Leaves = leaves,
            };
        }

        public Pageable<EmployeeResponse> GetList(EmployeeSearchRequest request)
        {
            var query = _db.Employees
                .Where(p => p.IsActive == request.IsActive)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(p =>
                    p.NIK.ToLower() == request.Search.ToLower() ||
                    p.Name.ToLower() == request.Search.ToLower());
            }

            if (!string.IsNullOrEmpty(request.JoinDateRangeBegin))
            {
                query = query.Where(p => p.JoinDate > DateOnly.ParseExact(request.JoinDateRangeBegin, "yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(request.JoinDateRangeEnd))
            {
                query = query.Where(p => p.JoinDate < DateOnly.ParseExact(request.JoinDateRangeEnd, "yyy-MM-dd"));
            }

            var data = query
                .Select(_employee => new EmployeeResponse
                {
                    NIK = _employee.NIK,
                    Name = _employee.Name,
                    Sex = _employee.Sex,
                    JoinDate = _employee.JoinDate.ToString("yyy-MM-dd"),
                    WorkLength = _employee.WorkLength,
                    PositionId = _employee.PositionId,
                    IsActive = _employee.IsActive,
                    DigitalSignature = _employee.DigitalSignature,
                })
                .ToList();

            var pagedData = new Pageable<EmployeeResponse>(data, request.Page, request.PageSize);
            foreach (var response in pagedData.Content.Where(p => p.PositionId != null))
            {
                response.Position = _db.Position
                    .Where(p => p.Id == response.PositionId)
                    .FirstOrDefault()?
                    .Name;
            }

            return pagedData;
        }

        public Employee GetEmployeeByNIK(string nik)
        {
            return _db.Employees
                .Where(p => p.NIK.ToLower() == nik)
                .AsNoTracking()
                .FirstOrDefault();
        }
        
        public HistoryPassword GetHistoryPasswordByNIK(long id, string hash)
        {
            return _db.HistoryPassword
                .Where(p => (p.EmployeeId == id) && (p.Password == hash))
                .AsNoTracking()
                .FirstOrDefault();
        }


        public Employee GetEmployeeById(long id)
        {
            return _db.Employees
                .Find(id);
        }


        public AuthLoginResponse AuthenticateUser(string nik, string password)
        {
            var employeeResponse = this.GetEmployeeByNIK(nik);

            if (employeeResponse == null) throw new Exception("NIK tidak ada!");

            // TODO check password hash 
            if (!Hasher.VerifyPassword(password, employeeResponse.Password))
            {
                throw new Exception("NIK Atau Password Salah");
            }

            // TODO check password hash 
            if ((DateTime.Now - employeeResponse.LastUpdatePassword).TotalDays > 30)
            {
                throw new Exception("Password Expired ,  Silahkan forgot password");
            }

            var jwtToken = new JwtService().GenerateToken(nik);
            return new AuthLoginResponse(jwtToken);

            /*if (data == null) throw new Exception("NIK tidak ada!");
        return data;*/
        }

        public BaseResponse UpdatePinSignature(string nik, string lastSignature, string newSignature)
        {
            Employee employee = this.GetEmployeeByNIK(nik);

            if (employee == null) throw new Exception("NIK tidak ada!");


            // TODO check password hash 
            if (!Hasher.VerifyPassword(lastSignature, employee.DigitalSignature))
            {
                throw new Exception("Signature Lama Tidak Sesuai");
            }

            employee.DigitalSignature = Hasher.HashString(newSignature);
            _db.Employees.Update(employee);

            //TODO : Simpan last signature ke table  agar bisa di check apakah signature sudah di pakai
            return new BaseResponse(true, "Signature Terupdate");
        }
        
        public BaseResponse ResetPassword(string nik, string password)
        {
            Employee employee = this.GetEmployeeByNIK(nik);

            if (employee == null) throw new Exception("NIK tidak ada!");

            string hashPassword = Hasher.HashString(password);

            // check history password
            HistoryPassword historyPassword = this.GetHistoryPasswordByNIK(employee.Id, hashPassword);
            
            if (historyPassword != null) throw new Exception("Password sudah digunakan sebelumnya!");

            try
            {
                employee.Password = hashPassword;
            
                _db.Employees.Update(employee);
            
                _db.HistoryPassword.Add(new HistoryPassword
                {
                    EmployeeId = employee.Id,
                    Password = employee.Password,
                });
            
                _db.SaveChanges();
                return new BaseResponse(true, "Password Terupdate");
            }
            catch (Exception exception)
            {
                return new BaseResponse(true, exception.Message);
            }
        }

        public BaseResponse AddPinSignature(string nik, string newSignature)
        {
            Employee employee = this.GetEmployeeByNIK(nik);

            if (employee == null) throw new Exception("NIK tidak ada!");

            employee.DigitalSignature = Hasher.HashString(newSignature);
            _db.Employees.Update(employee);

            //TODO : Simpan last signature ke table  agar bisa di check apakah signature sudah di pakai
            return new BaseResponse(true, "Signature Ditambahkan");
        }


        public void EmployeeAdd(EmployeeAddRequest request)
        {
            var data = _db.Employees
                .Where(p => p.NIK.ToLower() == request.NIK)
                .AsNoTracking()
                .FirstOrDefault();
            if (data != null) throw new Exception("NIK sudah ada!");

            try
            {
                var newEmployee = new Employee
                {
                    NIK = request.NIK,
                    Name = request.Name,
                    Sex = request.Sex,
                    JoinDate = DateOnly.ParseExact(request.JoinDate, "yyyy-MM-dd"),
                    WorkLength = request.WorkLength,
                    PositionId = request.PositionId,
                    Email = request.Email,
                };

                _db.Employees.Add(newEmployee);
                _db.SaveChanges();

                _db.HistoryDigitalSignature.Add(new HistoryDigitalSignature
                {
                    EmployeeId = newEmployee.Id,
                    DigitalSignature = newEmployee.DigitalSignature,
                });
                _db.SaveChanges();

                _db.HistoryPassword.Add(new HistoryPassword
                {
                    EmployeeId = newEmployee.Id,
                    Password = newEmployee.Password,
                });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            _auditLogService.AddAuditLog(AuditLogConstant.Employee, request.Name, AuditLogConstant.Create, 0);
            _auditLogService.AddAuditLog(AuditLogConstant.HistoryDigitalSignature, request.Name,
                AuditLogConstant.Create, 0);
        }

        public void EmployeeUpdate(EmployeeUpdateRequest request)
        {
            var data = _db.Employees
                .Where(p => p.NIK.ToLower() == request.NIK)
                .AsNoTracking()
                .FirstOrDefault();
            if (data == null) throw new Exception("NIK tidak ada!");

            try
            {
                data.NIK = request.NIK;
                data.Name = request.Name;
                data.Sex = request.Sex;
                data.JoinDate = DateOnly.ParseExact(request.JoinDate, "yyyy-MM-dd");
                data.WorkLength = request.WorkLength;
                data.PositionId = request.PositionId;
                data.UpdatedBy = null;
                data.UpdatedDate = DateTime.UtcNow;
                data.IsOnLeave = request.IsOnLeave;
                data.Email = request.Email;

                _db.Employees.Update(data);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            _auditLogService.AddAuditLog(AuditLogConstant.Employee, request.Name, AuditLogConstant.Update, 0);
        }

        public void EmployeeDelete(string nik)
        {
            string name = "";
            var data = _db.Employees
                .Where(p => p.NIK.ToLower() == nik)
                .AsNoTracking()
                .FirstOrDefault();
            if (data == null) throw new Exception("NIK tidak ada!");

            try
            {
                name = data.Name;
                _db.Employees.Remove(data);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            _auditLogService.AddAuditLog(AuditLogConstant.Employee, name, AuditLogConstant.Delete, 0);
        }
    }
}