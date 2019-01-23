using Microsoft.EntityFrameworkCore.Migrations;

namespace Airplanes.Migrations
{
    public partial class updateDB04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RollNumber",
                table: "DbFlight",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RestTicket",
                table: "DbAvailableSeat",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RollNumber",
                table: "DbFlight");

            migrationBuilder.DropColumn(
                name: "RestTicket",
                table: "DbAvailableSeat");
        }
    }
}
