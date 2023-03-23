using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class AddTableNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<long>(type: "bigint", nullable: false),
                    employee_backup_id = table.Column<long>(type: "bigint", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 7, 22, 39, 426, DateTimeKind.Utc).AddTicks(4623));

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 7, 22, 39, 426, DateTimeKind.Utc).AddTicks(4647));
        }
    }
}
