using BigioHrServices.Utilities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BigioHrServices.Db.Entities
{
    public class HistoryPassword
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [ForeignKey("Employee")]
        [Column("employee_id")]
        public long? EmployeeId { get; set; }
        [Required]
        [Column("password")]
        public string Password { get; set; } = Hasher.HashDefaultPassword();

        public virtual Employee? Employee { get; set; }
    }
}
