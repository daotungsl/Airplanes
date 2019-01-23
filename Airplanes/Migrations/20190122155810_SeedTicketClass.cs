using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedTicketClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] TicketClassData = { "Business Class", "First Class", "Club Class", "Smoke Class", "Non Smoke Class" };
            int[] TicketClassPrice = { 5000000,4000000,4500000,3000000,2500000 };
            for (int num = 0; num < TicketClassData.Length; num++)
            {

                migrationBuilder.InsertData(
             table: "DbTicketClass",
             columns: new[] { "TicketClassName", "Price",  "CreatedAt", "UpdatedAt" },
             values: new object[] { TicketClassData[num], TicketClassPrice[num], DateTime.Now, DateTime.Now }
             );


            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
