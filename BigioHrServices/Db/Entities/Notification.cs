using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigioHrServices.Db.Entities;

[Table("Notification")]
public class Notification : BaseEntities
{
    public Notification()
    {
    }

    [Key] [Column("id")] public long Id { get; set; }
    [Required] [Column("employee_id")] [ForeignKey("Employee")] public long EmployeeId { get; set; }
    [Required] [Column("leave_id")] [ForeignKey("Leave")] public long LeaveId { get; set; }
    [Required] [Column("is_view")] public bool IsView { get; set; }
    [Required] [Column("content")] public string Content { get; set; }
    
    public virtual Employee Employee { get; set; }
    public virtual Leave Leave { get; set; }
}