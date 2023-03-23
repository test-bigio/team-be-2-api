using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigioHrServices.Migrations
{
    public partial class UpdateTableNotificationAddFKtoLeave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notification_leave_id",
                table: "Notification",
                column: "leave_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_Leave_leave_id",
                table: "Notification",
                column: "leave_id",
                principalTable: "Leave",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_Leave_leave_id",
                table: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_leave_id",
                table: "Notification");
        }
    }
}
