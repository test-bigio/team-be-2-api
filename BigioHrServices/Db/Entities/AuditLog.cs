using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BigioHrServices.Db.Entities
{
    public class AuditLog : BaseEntities
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("module_name")]
        public string ModuleName { get; set; } = string.Empty;
        [Required]
        [Column("activity")]
        public string Activity { get; set; } = string.Empty;
        [Required]
        [Column("detail")]
        public string Detail { get; set; } = string.Empty;
    }
}
