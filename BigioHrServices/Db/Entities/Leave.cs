using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BigioHrServices.Db.Entities
{
    [Table("Leave")]
    public class Leave : BaseEntities
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        
        [Required] 
        [Column("employee_id")] 
        [ForeignKey("Employee")]
        public long EmployeeId { get; set; }

        [Required]
        [Column("leave_date")]
        public DateOnly leaveDate { get; set; }
        
        [Column("task_detail")]
        public string? TaskDetail { get; set; }
        
        [Column("is_approve")]
        public bool IsApprove { get; set; }
        
        [Column("delegation_matrix_id")] 
        [ForeignKey("DelegationMatrix")]
        public long? DelegationMatrixId { get; set; }

        [Column("reviewed_by")]
        public string? reviewedBy { get; set; }
        
        [Column("reviewed_date")]
        public DateTime? reviewedDate { get; set; }
        
        public virtual Employee Employee { get; set; }
        public virtual DelegationMatrix DelegationMatrix { get; set; }
    }
}
