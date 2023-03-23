using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class AddTableLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leave",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    employee_id = table.Column<long>(type: "bigint", nullable: false),
                    leave_date = table.Column<DateOnly>(type: "date", nullable: false),
                    task_detail = table.Column<string>(type: "text", nullable: true),
                    is_approve = table.Column<bool>(type: "boolean", nullable: false),
                    delegation_matrix_id = table.Column<long>(type: "bigint", nullable: false),
                    reviewed_by = table.Column<string>(type: "text", nullable: true),
                    reviewed_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<long>(type: "bigint", nullable: true),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_by = table.Column<long>(type: "bigint", nullable: true),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leave", x => x.id);
                    table.ForeignKey(
                        name: "FK_Leave_DelegationMatrix_delegation_matrix_id",
                        column: x => x.delegation_matrix_id,
                        principalTable: "DelegationMatrix",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leave_Employee_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employee",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Leave_delegation_matrix_id",
                table: "Leave",
                column: "delegation_matrix_id");

            migrationBuilder.CreateIndex(
                name: "IX_Leave_employee_id",
                table: "Leave",
                column: "employee_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leave");

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 1L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 7, 15, 43, 555, DateTimeKind.Utc).AddTicks(3172));

            migrationBuilder.UpdateData(
                table: "Position",
                keyColumn: "id",
                keyValue: 2L,
                column: "created_date",
                value: new DateTime(2023, 3, 22, 7, 15, 43, 555, DateTimeKind.Utc).AddTicks(3275));
        }
    }
}
