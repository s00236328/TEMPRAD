using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace S00236328_classlibrary.Migrations
{
    /// <inheritdoc />
    public partial class s00236328 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlightNo = table.Column<string>(type: "TEXT", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Origin = table.Column<string>(type: "TEXT", nullable: false),
                    Destination = table.Column<string>(type: "TEXT", nullable: false),
                    DestinationCountry = table.Column<string>(type: "TEXT", nullable: false),
                    MaxSeats = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    PassengerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassengerName = table.Column<string>(type: "TEXT", nullable: false),
                    Passport = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.PassengerId);
                });

            migrationBuilder.CreateTable(
                name: "PassengerBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FlightId = table.Column<int>(type: "INTEGER", nullable: false),
                    PassengerId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketCost = table.Column<double>(type: "REAL", nullable: false),
                    TicketType = table.Column<int>(type: "INTEGER", nullable: false),
                    BaggageCharge = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassengerBookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassengerBookings_Passengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passengers",
                        principalColumn: "PassengerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "FlightId", "DepartureTime", "Destination", "DestinationCountry", "FlightNo", "MaxSeats", "Origin" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Rome", "Italy", "IT-001", 110, "Dublin" },
                    { 2, new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "London", "England", "EN-002", 110, "Dublin" },
                    { 3, new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Paris", "France", "FR-001", 120, "Dublin" },
                    { 4, new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Brussels", "Belgium", "BE-001", 88, "Dublin" },
                    { 5, new DateTime(2025, 1, 12, 22, 0, 0, 0, DateTimeKind.Unspecified), "Dublin", "Ireland", "DU-001", 110, "London" }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "PassengerId", "PassengerName", "Passport" },
                values: new object[,]
                {
                    { 1, "Fred Farnell", "P010203" },
                    { 2, "Tom McManus", "P896745" },
                    { 3, "Bill Trimble", "P231425" },
                    { 4, "Freda McDonald", "P235678" },
                    { 5, "Mary Malone", "P214587" },
                    { 6, "Tom McManus", "P893482" }
                });

            migrationBuilder.InsertData(
                table: "PassengerBookings",
                columns: new[] { "Id", "BaggageCharge", "FlightId", "PassengerId", "TicketCost", "TicketType" },
                values: new object[,]
                {
                    { 1, 30, 2, 1, 51.829999999999998, 0 },
                    { 2, 10, 2, 2, 127.0, 1 },
                    { 3, 10, 3, 3, 140.0, 1 },
                    { 4, 15, 4, 4, 50.0, 0 },
                    { 5, 15, 1, 5, 69.0, 0 },
                    { 6, 10, 5, 6, 127.0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerBookings_FlightId",
                table: "PassengerBookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerBookings_PassengerId",
                table: "PassengerBookings",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerBookings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Passengers");
        }
    }
}
