using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedDbAirport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Airport Viet Nam
            string[] AirportNameVN = { "Côn Đảo", "Phù Cát", "Cà Mau", "Cần Thơ", "Buôn Ma Thuột",
                                    "Đà Nẵng", "Điện Biên Phủ", "Pleiku", "Cát Bi", "Nội Bài",
                                    "Tân Sơn Nhất", "Cam Ranh", "Rạch Giá", "Phú Quốc", "Liên Khương",
                                    "Vinh", "Tuy Hòa", "Đồng Hới", "Chu Lai", "Phú Bài", "Thọ Xuân", "Vân Đồn" };
          
            for (int num = 0; num < AirportNameVN.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId","CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameVN[num], num+1, DateTime.Now, DateTime.Now }
                 );
            };

            //City China
            string[] AirportNameChina = { "Bắc Kinh", "Hồng Kiều", "Bạch Vân", "Tiêu Sơn", "Song Lưu", "Hồng Kông", "Macau" };
            

            for (int num = 0; num < AirportNameChina.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameChina[num], num + 23, DateTime.Now, DateTime.Now }
                 );
            };


            //City Dai loan
            string[] AirportNameDailoan = { "Đào Viên", "Cao Hùng" };

            for (int num = 0; num < AirportNameDailoan.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameDailoan[num], num + 30, DateTime.Now, DateTime.Now }
                 );
            };

            //City Japan
            string[] AirportNameJapan = { "Fukuoka", "Chubu Centrair", "Kansai", "Tokyo", "Osaka" };

            for (int num = 0; num < AirportNameJapan.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameJapan[num], num + 32, DateTime.Now, DateTime.Now }
                 );
            };

            //City korea
            string[] AirportNameKorea = { "Gimhae", "Incheon" };

            for (int num = 0; num < AirportNameKorea.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameKorea[num], num + 37, DateTime.Now, DateTime.Now }
                 );
            };

            //City Campuchia
            string[] AirportNameCampuchia = { "Phnom Penh", "Siem Reap" };

            for (int num = 0; num < AirportNameCampuchia.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameCampuchia[num], num + 39, DateTime.Now, DateTime.Now }
                 );
            };

            //City laos
            string[] AirportNameLaos = { "Wattay", "Luang Phrabang" };

            for (int num = 0; num < AirportNameLaos.Length; num++)
            {
                migrationBuilder.InsertData(
                  table: "DbAirport",
                  columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                  values: new object[] { AirportNameLaos[num], num + 41, DateTime.Now, DateTime.Now }
                  );
            };

            //City Indo
            string[] AirportNameIndonesia = { "Soekarno-Hatta", "Ngurah Rai", "Kuala Namu" };

            for (int num = 0; num < AirportNameIndonesia.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameIndonesia[num], num + 43, DateTime.Now, DateTime.Now }
                 );
            };

            //City malaysia
            migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { "Kuala Lumpur", 46, DateTime.Now, DateTime.Now }
                 );

            //City Singapore
            migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { "Changi", 47, DateTime.Now, DateTime.Now }
                 );

            //Cyti France
            string[] AirportNameFrance = { "Charles De Gaulle", "Marseille Provence", "Montpellier", "Nice" };

            for (int num = 0; num < AirportNameFrance.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameFrance[num], num + 48, DateTime.Now, DateTime.Now }
                 );
            };

            //City Germany
            migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { "Frankfurt", 52, DateTime.Now, DateTime.Now }
                 );

            //City England
            migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { "London", 53, DateTime.Now, DateTime.Now }
                 );

            //City Australia 
            string[] AirportNameAustralia = { "Melbourne", "Sydney", "Darwin" };

            for (int num = 0; num < AirportNameAustralia.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameAustralia[num], 54, DateTime.Now, DateTime.Now }
                 );
            };

            //City New Zealand
            string[] AirportNameZealand = { "Auckland", "Christchurch", "Wellington" };

            for (int num = 0; num < AirportNameZealand.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameZealand[num], 57, DateTime.Now, DateTime.Now }
                 );
            };

            //City Thailand
            string[] AirportNameThailand = { "Survanabhumi", "Phuket" };

            for (int num = 0; num < AirportNameThailand.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameThailand[num], 60, DateTime.Now, DateTime.Now }
                 );
            };

            //City Nigeria
            migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { "Angeles", 62, DateTime.Now, DateTime.Now }
                 );

            //City Russia
            migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { "Moscow", 63, DateTime.Now, DateTime.Now }
                 );

            //City South Africa
            string[] AirportNameAfrica = { "Cape Town", "OR Tambo" };

            for (int num = 0; num < AirportNameAfrica.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameAfrica[num], 64, DateTime.Now, DateTime.Now }
                 );
            };

            //City United States
            string[] AirportNameUS = {  "Hartsfield", "Logan","Dallas-Forth Worth","Denver","Honolulu",
                                    "Los Angeles","Miami","Minneapolis","John F.Kennedy","Philadephia",
                                    "Portland","San Francisco","Seattle – Tacoma","Lambert" };


            for (int num = 0; num < AirportNameUS.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { AirportNameUS[num], num + 66, DateTime.Now, DateTime.Now }
                 );
            };

            //City Myanmar
            migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { "Yangon", 80, DateTime.Now, DateTime.Now }
                 );

            //City Czech Republic
            migrationBuilder.InsertData(
                 table: "DbAirport",
                 columns: new[] { "AirportName", "DbCityId", "CreatedAt", "UpdatedAt" },
                 values: new object[] { "Havel Prava", 81, DateTime.Now, DateTime.Now }
                 );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
