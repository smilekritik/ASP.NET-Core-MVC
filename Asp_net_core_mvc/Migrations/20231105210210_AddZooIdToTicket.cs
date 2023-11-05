using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp_net_core_mvc.Migrations
{
    /// <inheritdoc />
    public partial class AddZooIdToTicket : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Zoo_Zoo_ID",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_Zoo_ID",
                table: "Ticket");

            migrationBuilder.AddColumn<int>(
                name: "ZooId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ZooId",
                table: "Ticket",
                column: "ZooId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Zoo_ZooId",
                table: "Ticket",
                column: "ZooId",
                principalTable: "Zoo",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Zoo_ZooId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_ZooId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ZooId",
                table: "Ticket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Zoo_ID",
                table: "Ticket",
                column: "Zoo_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Zoo_Zoo_ID",
                table: "Ticket",
                column: "Zoo_ID",
                principalTable: "Zoo",
                principalColumn: "Id");
        }
    }
}
