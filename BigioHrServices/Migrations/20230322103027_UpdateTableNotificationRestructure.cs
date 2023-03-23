using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class UpdateTableNotificationRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "priority",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "employee_backup_id",
                table: "Notification",
                newName: "leave_id");

            migrationBuilder.AddColumn<string>(
                name: "content",
                table: "Notification",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "is_view",
                table: "Notification",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_employee_id",
                table: "Notification",
                column: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Employee_employee_id",
                table: "Notification",
                column: "employee_id",
                principalTable: "Employee",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Employee_employee_id",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_employee_id",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "content",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "is_view",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "leave_id",
                table: "Notification",
                newName: "employee_backup_id");

            migrationBuilder.AddColumn<int>(
                name: "priority",
                table: "Notification",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
