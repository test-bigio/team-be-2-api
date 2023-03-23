using BigioHrServices.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BigioHrServices.Db.Seeder
{
    public static class DataSeeder
    {
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(new Position
            {
                Id = 1,
                Code = "001",
                Level = 2,
                Name = "Pegawai",
                IsActive = true,
                CreatedDate = new DateTime(2023, 3, 22, 12, 0, 0, 0, DateTimeKind.Utc),
        });
            modelBuilder.Entity<Position>().HasData(new Position
            {
                Id = 2,
                Code = "002",
                Level = 1,
                Name = "Supervisor",
                IsActive = true,
                CreatedDate = new DateTime(2023, 3, 22, 12, 0, 0, 0, DateTimeKind.Utc),
            });
        }
    }
}
