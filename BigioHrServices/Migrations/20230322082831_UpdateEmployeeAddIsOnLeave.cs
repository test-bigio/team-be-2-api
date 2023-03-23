using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class UpdateEmployeeAddIsOnLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_on_leave",
                table: "Employee",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 8, 28, 31, 472, DateTimeKind.Utc).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 8, 28, 31, 472, DateTimeKind.Utc).AddTicks(9463));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_on_leave",
                table: "Employee");

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 8, 0, 18, 208, DateTimeKind.Utc).AddTicks(674));

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 8, 0, 18, 208, DateTimeKind.Utc).AddTicks(701));
        }
    }
}
