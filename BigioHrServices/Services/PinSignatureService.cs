using BigioHrServices.Db;
using BigioHrServices.Db.Entities;
using BigioHrServices.Model;
using BigioHrServices.Model.Datatable;
using BigioHrServices.Model.Employee;
using Microsoft.EntityFrameworkCore;
using BigioHrServices.Model.Auth;
using BigioHrServices.Utilities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Internal;

namespace BigioHrServices.Services
{
    public interface IPinSignatureService
    {
        public List<HistoryDigitalSignature> GetSignatureByEmployeeId(long id);
        public bool CleanExtraSignatureByEmployee(long id);

        public bool AppendSignatureHistory(long id, string signaturePin);

        public bool CheckSignaturePinHistory(long id, string signaturePin);
    }

    public class PinSignatureService : IPinSignatureService
    {
        private readonly ApplicationDbContext _db;

        public PinSignatureService(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<HistoryDigitalSignature> GetSignatureByEmployeeId(long id)
        {
            return _db.HistoryDigitalSignature.Where(q => q.EmployeeId == id)
                .OrderByDescending(signature => signature.CreatedDate)
                .AsNoTracking()
                .AsQueryable().ToList();
        }
        public bool AppendSignatureHistory(long id, string signaturePin)
        {
            // Check signature apakah sudah ada di history / bleum 
            if (!this.CheckSignaturePinHistory(id, signaturePin))
            {
                return false;
            }
            // Hapus Signature yang lama dan sisakan 2 
            this.CleanExtraSignatureByEmployee(id);

            // Sipa
            HistoryDigitalSignature historyDigitalSignature = new HistoryDigitalSignature();
            historyDigitalSignature.DigitalSignature = Hasher.HashString(signaturePin);
            historyDigitalSignature.EmployeeId = id;
            historyDigitalSignature.CreatedBy = id;
            _db.HistoryDigitalSignature.Add(historyDigitalSignature);
            _db.SaveChanges();
            return true;

        }

        public bool CheckSignaturePinHistory(long id, string signaturePin)
        {
            List<HistoryDigitalSignature> historyDigitalSignatures = GetSignatureByEmployeeId(id);
            HistoryDigitalSignature historyDigitalSignature  =  historyDigitalSignatures.Find(signature =>
            {
                return Hasher.VerifyPassword(signaturePin, signature.DigitalSignature);
            });
            
            
            if (historyDigitalSignature != null)
            {
                return false;
            }
            
            return true;
        }

        public bool CleanExtraSignatureByEmployee(long id)
        {
            List<HistoryDigitalSignature> historyDigitalSignatures = GetSignatureByEmployeeId(id);
            if (historyDigitalSignatures.Count > 3)
            {
                List<HistoryDigitalSignature> tobeDeleted = historyDigitalSignatures
                    .Skip(2)
                    .ToList();

                _db.HistoryDigitalSignature.RemoveRange(tobeDeleted);
                _db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}