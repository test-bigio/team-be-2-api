using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class UpdateEmployeeAddOTP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "otp",
                table: "Employee",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "otp",
                table: "Employee");
        }
    }
}
