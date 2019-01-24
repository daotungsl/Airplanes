using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedDbFlight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // the wourld
            Random randomFlight = new Random();
            string[] RollNumberData = { "CX","SU","AK","BX","CA",
                                        "AF","NX","AA","OZ","PG",
                                        "BA","DL","DA","KA","HX",
                                        "JL","KE","JT","QF","SQ",
                                        "MI","VJ","VN","FD","TG" };

            for (int num = 1; num < 725; num++)
            {
                migrationBuilder.InsertData(
                table: "DbFlight",
                columns: new[] { "DbRouteId", "DbPlaneId", "FlightTime", "TimeOfTransit", "FlightDuration", "CreatedAt", "UpdatedAt", "Status", "RollNumber" },
                values: new object[] { num, randomFlight.Next(1, 9), DateTime.Now.AddDays(randomFlight.Next(10, 60)).AddHours(randomFlight.Next(1, 24)).AddMinutes(randomFlight.Next(1, 60)),
                                        0, randomFlight.Next(30, 180), DateTime.Now, DateTime.Now, 0, RollNumberData[randomFlight.Next(0 , 24)]+" "+randomFlight.Next(100, 500)}
                );
            };
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
