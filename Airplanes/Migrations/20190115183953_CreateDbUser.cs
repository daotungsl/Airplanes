using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Airplanes.Migrations
{
    public partial class CreateDbUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UId = table.Column<long>(nullable: false),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(maxLength: 30, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    IdNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Phone = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    RewardPoints = table.Column<int>(nullable: false),
                    EmailVerifyStatus = table.Column<int>(nullable: false),
                    PhoneVerifyStatus = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbRewardPointsLog",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UId = table.Column<long>(nullable: false),
                    NameLog = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<long>(nullable: false),
                    DbUserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbRewardPointsLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbRewardPointsLog_DbUser_DbUserId",
                        column: x => x.DbUserId,
                        principalTable: "DbUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbRewardPointsLog_DbUserId",
                table: "DbRewardPointsLog",
                column: "DbUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbRewardPointsLog");

            migrationBuilder.DropTable(
                name: "DbUser");
        }
    }
}
