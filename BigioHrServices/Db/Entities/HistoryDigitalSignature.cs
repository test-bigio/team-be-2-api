using BigioHrServices.Utilities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BigioHrServices.Db.Entities
{
    public class HistoryDigitalSignature : BaseEntities
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [ForeignKey("Employee")]
        [Column("employee_id")]
        public long? EmployeeId { get; set; }
        [Required]
        [Column("digital_signature")]
        public string DigitalSignature { get; set; } = Hasher.HashDefaultPIN();

        public virtual Employee? Employee { get; set; }
    }
}
