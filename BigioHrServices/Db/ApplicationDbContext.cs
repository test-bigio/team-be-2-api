using BigioHrServices.Db.Entities;
using BigioHrServices.Db.Seeder;
using Microsoft.EntityFrameworkCore;

namespace BigioHrServices.Db
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Position { get; set; }
        public DbSet<HistoryDigitalSignature> HistoryDigitalSignature { get; set; }
        public DbSet<DelegationMatrix> DelegationMatrix { get; set; }
        public DbSet<Leave> Leave { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        public DbSet<HistoryPassword> HistoryPassword { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedPositions();
        }
    }
}
