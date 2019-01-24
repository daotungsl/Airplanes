using Microsoft.EntityFrameworkCore.Migrations;

namespace Airplanes.Migrations
{
    public partial class updateDbTicketClassVer2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "DbTicketClass",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "DbTicketClass");
        }
    }
}
