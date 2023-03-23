using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class UpdateEmployeeAddEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Employee",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Employee");
        }
    }
}
