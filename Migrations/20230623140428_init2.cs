using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace TicketTravel.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingTicketIdBooking",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HistoryBookings",
                columns: table => new
                {
                    IdHistoryBooking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryBookings", x => x.IdHistoryBooking);
                    table.ForeignKey(
                        name: "FK_HistoryBookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TransportationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TransportationTypeName = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportationTypes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transportations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NameTransportation = table.Column<string>(type: "longtext", nullable: false),
                    TransportationTypeId = table.Column<int>(type: "int", nullable: false),
                    seat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportations_TransportationTypes_TransportationTypeId",
                        column: x => x.TransportationTypeId,
                        principalTable: "TransportationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TransportationId = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "longtext", nullable: false),
                    Schedule = table.Column<DateOnly>(type: "date", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time", nullable: false),
                    HistoryBookingIdHistoryBooking = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_HistoryBookings_HistoryBookingIdHistoryBooking",
                        column: x => x.HistoryBookingIdHistoryBooking,
                        principalTable: "HistoryBookings",
                        principalColumn: "IdHistoryBooking");
                    table.ForeignKey(
                        name: "FK_Tickets_Transportations_TransportationId",
                        column: x => x.TransportationId,
                        principalTable: "Transportations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BookingTickets",
                columns: table => new
                {
                    IdBooking = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TicketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingTickets", x => x.IdBooking);
                    table.ForeignKey(
                        name: "FK_BookingTickets_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BookingTicketIdBooking",
                table: "Users",
                column: "BookingTicketIdBooking");

            migrationBuilder.CreateIndex(
                name: "IX_BookingTickets_TicketId",
                table: "BookingTickets",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryBookings_UserId",
                table: "HistoryBookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_HistoryBookingIdHistoryBooking",
                table: "Tickets",
                column: "HistoryBookingIdHistoryBooking");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TransportationId",
                table: "Tickets",
                column: "TransportationId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportations_TransportationTypeId",
                table: "Transportations",
                column: "TransportationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_BookingTickets_BookingTicketIdBooking",
                table: "Users",
                column: "BookingTicketIdBooking",
                principalTable: "BookingTickets",
                principalColumn: "IdBooking");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_BookingTickets_BookingTicketIdBooking",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BookingTickets");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "HistoryBookings");

            migrationBuilder.DropTable(
                name: "Transportations");

            migrationBuilder.DropTable(
                name: "TransportationTypes");

            migrationBuilder.DropIndex(
                name: "IX_Users_BookingTicketIdBooking",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BookingTicketIdBooking",
                table: "Users");
        }
    }
}
