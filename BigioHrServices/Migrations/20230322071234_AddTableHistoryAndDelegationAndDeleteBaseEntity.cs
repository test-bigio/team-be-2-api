using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class AddTableHistoryAndDelegationAndDeleteBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "DelegationMatrix",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<long>(type: "bigint", nullable: false),
                    employee_backup_id = table.Column<long>(type: "bigint", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelegationMatrix", x => x.id);
                    table.ForeignKey(
                        name: "FK_DelegationMatrix_Employee_employee_backup_id",
                        column: x => x.employee_backup_id,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DelegationMatrix_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryDigitalSignature",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<long>(type: "bigint", nullable: true),
                    digital_signature = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryDigitalSignature", x => x.id);
                    table.ForeignKey(
                        name: "FK_HistoryDigitalSignature_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DelegationMatrix_employee_backup_id",
                table: "DelegationMatrix",
                column: "employee_backup_id");

            migrationBuilder.CreateIndex(
                name: "IX_DelegationMatrix_employee_id",
                table: "DelegationMatrix",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryDigitalSignature_employee_id",
                table: "HistoryDigitalSignature",
                column: "employee_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DelegationMatrix");

            migrationBuilder.DropTable(
                name: "HistoryDigitalSignature");

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "Position",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "Position",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "Position",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "Position",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "created_by",
                table: "Employee",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "Employee",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "updated_by",
                table: "Employee",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "Employee",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 1L,
                columns: new[] { "created_by", "created_date" },
                values: new object[] { "", new DateTime(2023, 3, 22, 6, 31, 18, 155, DateTimeKind.Utc).AddTicks(7272) });

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 2L,
                columns: new[] { "created_by", "created_date" },
                values: new object[] { "", new DateTime(2023, 3, 22, 6, 31, 18, 155, DateTimeKind.Utc).AddTicks(7297) });
        }
    }
}
