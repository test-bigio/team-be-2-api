using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigioHrServices.Db.Entities
{
    [Table("DelegationMatrix")]
    public class DelegationMatrix : BaseEntities
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("employee_id")]
        [ForeignKey("Employee")]
        public long? EmployeeId { get; set; }
        
        [Required]
        [Column("employee_backup_id")]
        [ForeignKey("EmployeeBackupId")]
        public long? EmployeeBackupId { get; set; }
        
        [Column("priority")]
        public int Priority { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee EmployeeBackup { get; set; }
    }
}
