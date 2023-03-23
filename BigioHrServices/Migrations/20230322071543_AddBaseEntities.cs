using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class AddBaseEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "Position",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "Position",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "Position",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "Position",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "HistoryDigitalSignature",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "HistoryDigitalSignature",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "HistoryDigitalSignature",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "HistoryDigitalSignature",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "Employee",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "Employee",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "Employee",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "created_by",
                table: "DelegationMatrix",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_date",
                table: "DelegationMatrix",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "updated_by",
                table: "DelegationMatrix",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_date",
                table: "DelegationMatrix",
                type: "timestamp with time zone",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "HistoryDigitalSignature");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "HistoryDigitalSignature");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "HistoryDigitalSignature");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "HistoryDigitalSignature");

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

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "DelegationMatrix");

            migrationBuilder.DropColumn(
                name: "created_date",
                table: "DelegationMatrix");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "DelegationMatrix");

            migrationBuilder.DropColumn(
                name: "updated_date",
                table: "DelegationMatrix");
        }
    }
}
