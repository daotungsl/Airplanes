using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedDbFlight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // the wourld
            Random randomPlane = new Random();


            for (int num = 1; num < 725; num++)
            {
                migrationBuilder.InsertData(
                table: "DbFlight",
                columns: new[] { "DbRouteId", "DbPlaneId", "FlightTime", "TimeOfTransit", "FlightDuration", "CreatedAt", "UpdatedAt", "Status" },
                values: new object[] { num, randomPlane.Next(1, 8), DateTime.Now.AddDays(randomPlane.Next(10, 60)).AddHours(randomPlane.Next(1, 24)).AddMinutes(randomPlane.Next(1, 60)), 0, randomPlane.Next(30, 180), DateTime.Now, DateTime.Now, 0 }
                );
            };
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
