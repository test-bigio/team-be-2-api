using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class UpdateEmployeePositionFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "position",
                table: "Employee");

            migrationBuilder.AlterColumn<long>(
                name: "position_id",
                table: "Employee",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<string>(type: "text", nullable: false),
                    level = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<string>(type: "text", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "id", "code", "created_by", "created_date", "is_active", "level", "name", "updated_by", "updated_date" },
                values: new object[,]
                {
                    { 1L, "001", "", new DateTime(2023, 3, 22, 6, 31, 18, 155, DateTimeKind.Utc).AddTicks(7272), true, 2, "Pegawai", null, null },
                    { 2L, "002", "", new DateTime(2023, 3, 22, 6, 31, 18, 155, DateTimeKind.Utc).AddTicks(7297), true, 1, "Supervisor", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_position_id",
                table: "Employee",
                column: "position_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Position_position_id",
                table: "Employee",
                column: "position_id",
                principalTable: "Position",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Position_position_id",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Employee_position_id",
                table: "Employee");

            migrationBuilder.AlterColumn<long>(
                name: "position_id",
                table: "Employee",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "position",
                table: "Employee",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
