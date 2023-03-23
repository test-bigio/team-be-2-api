using BigioHrServices.Constant;
using BigioHrServices.Db;
using BigioHrServices.Db.Entities;
using Microsoft.EntityFrameworkCore;
using BigioHrServices.Model.Auth;
using BigioHrServices.Utilities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Internal;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Employee;
using BigioHrServices.Model;

namespace BigioHrServices.Services
{
    public interface IAuditLogService
    {
        public void AddAuditLog(string module, string name, string action, long userId);
    }
    public class AuditLogService : IAuditLogService
    {
        private readonly ApplicationDbContext _db;

        public AuditLogService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void AddAuditLog(string module, string name, string action, long userId)
        {
            try
            {
                string Detail = string.Format(AuditLogConstant.Detail, module, name, action, userId.ToString(), DateTime.UtcNow.ToString());
                _db.AuditLog.Add(new AuditLog
                {
                    ModuleName = module,
                    Activity = action,
                    Detail = Detail,
                    CreatedBy = 0,
                    CreatedDate = DateTime.UtcNow,
                });
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
