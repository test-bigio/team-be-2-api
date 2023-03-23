using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class AddTableAuditLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    module_name = table.Column<string>(type: "text", nullable: false),
                    activity = table.Column<string>(type: "text", nullable: false),
                    detail = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.id);
                });

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 12, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 12, 0, 0, 0, DateTimeKind.Utc));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog");

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
    }
}
