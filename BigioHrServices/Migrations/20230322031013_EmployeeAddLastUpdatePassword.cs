﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class EmployeeAddLastUpdatePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "last_update_password",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_update_password",
                table: "Employees");
        }
    }
}
