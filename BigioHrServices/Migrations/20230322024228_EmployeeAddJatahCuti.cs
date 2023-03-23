using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class EmployeeAddJatahCuti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "jatah_cuti",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jatah_cuti",
                table: "Employees");
        }
    }
}
