using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BigioHrServices.Db.Entities
{
    public class Position : BaseEntities
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("code")]
        public string Code { get; set; }
        [Required]
        [Column("level")]
        public int Level { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }
        [Required]
        [Column("is_active")]
        public bool IsActive { get; set; } = true;
    }
}
