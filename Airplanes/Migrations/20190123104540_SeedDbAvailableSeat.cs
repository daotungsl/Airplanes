using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedDbAvailableSeat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            int NumQuantity;
            for (int num = 1; num < 725; num++)
            {
                NumQuantity = 10;
                for (int NumClassTicket = 1; NumClassTicket <= 5; NumClassTicket++, NumQuantity += 10)
                {
                    migrationBuilder.InsertData(
                       table: "DbAvailableSeat",
                       columns: new[] { "DbFlightId", "TicketClassId", "Quantity", "CreatedAt", "UpdatedAt", "RestTicket" },
                       values: new object[] { num, NumClassTicket, NumQuantity, DateTime.Now, DateTime.Now, NumQuantity }
                      );
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
