using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SupportTicketManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "TicketStatusLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Tickets",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusLogs_TicketID",
                table: "TicketStatusLogs",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketStatusLogs_UserID",
                table: "TicketStatusLogs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserID",
                table: "Tickets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_TicketID",
                table: "TicketComments",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComments_UserID",
                table: "TicketComments",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Tickets_TicketID",
                table: "TicketComments",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketComments_Users_UserID",
                table: "TicketComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_UserID",
                table: "Tickets",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusLogs_Tickets_TicketID",
                table: "TicketStatusLogs",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketStatusLogs_Users_UserID",
                table: "TicketStatusLogs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Tickets_TicketID",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketComments_Users_UserID",
                table: "TicketComments");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusLogs_Tickets_TicketID",
                table: "TicketStatusLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketStatusLogs_Users_UserID",
                table: "TicketStatusLogs");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatusLogs_TicketID",
                table: "TicketStatusLogs");

            migrationBuilder.DropIndex(
                name: "IX_TicketStatusLogs_UserID",
                table: "TicketStatusLogs");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_TicketComments_TicketID",
                table: "TicketComments");

            migrationBuilder.DropIndex(
                name: "IX_TicketComments_UserID",
                table: "TicketComments");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "TicketStatusLogs");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Tickets");
        }
    }
}
