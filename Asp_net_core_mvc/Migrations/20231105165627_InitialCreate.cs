using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Asp_net_core_mvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronimic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone_numer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Worker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronimic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportID = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worker", x => x.Id);
                    table.CheckConstraint("Salary", "[Salary] > 4200");
                });

            migrationBuilder.CreateTable(
                name: "Zoo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Workers_Ammount = table.Column<int>(type: "int", nullable: false),
                    Aviary_Ammount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoo", x => x.Id);
                    table.CheckConstraint("Aviary_Ammount", "[Aviary_Ammount] > 0");
                    table.CheckConstraint("Workers_Ammount", "[Workers_Ammount] > 0");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zoo_ID = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.CheckConstraint("Cost", "[Cost] > 0");
                    table.ForeignKey(
                        name: "FK_Ticket_Zoo_Zoo_ID",
                        column: x => x.Zoo_ID,
                        principalTable: "Zoo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Aviary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Animals_Ammount = table.Column<int>(type: "int", nullable: false),
                    Ticket_ID = table.Column<int>(type: "int", nullable: true),
                    TicketId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aviary", x => x.Id);
                    table.CheckConstraint("Animals_ammount", "[Animals_ammount] > 0");
                    table.ForeignKey(
                        name: "FK_Aviary_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerTicket",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    TicketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTicket", x => new { x.CustomersId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_CustomerTicket_Customer_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerTicket_Ticket_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aviary_ID = table.Column<int>(type: "int", nullable: false),
                    AviaryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type_Animal_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                    table.CheckConstraint("Age", "[Age] > 0");
                    table.CheckConstraint("Weight", "[Weight] > 0");
                    table.ForeignKey(
                        name: "FK_Animal_Aviary_AviaryId",
                        column: x => x.AviaryId,
                        principalTable: "Aviary",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AviaryWorker",
                columns: table => new
                {
                    AviariesId = table.Column<int>(type: "int", nullable: false),
                    WorkersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AviaryWorker", x => new { x.AviariesId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_AviaryWorker_Aviary_AviariesId",
                        column: x => x.AviariesId,
                        principalTable: "Aviary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AviaryWorker_Worker_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Worker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Type_Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specifics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AviaryId = table.Column<int>(type: "int", nullable: true),
                    SomeInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_Animal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Type_Animal_Aviary_AviaryId",
                        column: x => x.AviaryId,
                        principalTable: "Aviary",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Zoo",
                columns: new[] { "Id", "Aviary_Ammount", "Name", "Workers_Ammount" },
                values: new object[,]
                {
                    { 1, 2, "12 month", 2 },
                    { 2, 2, "Kyiv", 4 },
                    { 3, 2, "International", 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animal_AviaryId",
                table: "Animal",
                column: "AviaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Aviary_TicketId",
                table: "Aviary",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_AviaryWorker_WorkersId",
                table: "AviaryWorker",
                column: "WorkersId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Telephone_numer",
                table: "Customer",
                column: "Telephone_numer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerTicket_TicketsId",
                table: "CustomerTicket",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_Zoo_ID",
                table: "Ticket",
                column: "Zoo_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Type_Animal_AviaryId",
                table: "Type_Animal",
                column: "AviaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "AviaryWorker");

            migrationBuilder.DropTable(
                name: "CustomerTicket");

            migrationBuilder.DropTable(
                name: "Type_Animal");

            migrationBuilder.DropTable(
                name: "Worker");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Aviary");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Zoo");
        }
    }
}
