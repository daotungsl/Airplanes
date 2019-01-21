using Airplanes.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedDbCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // City Viet Nam
            string[] CityDataVN = { "Côn Đảo", "Phù Cát", "Cà Mau", "Cần Thơ", "Buôn Ma Thuột",
                                    "Đà Nẵng", "Điện Biên Phủ", "Pleiku", "Cát Bi", "Nội Bài",
                                    "Tân Sơn Nhất", "Cam Ranh", "Rạch Giá", "Phú Quốc", "Liên Khương",
                                    "Vinh", "Tuy Hòa", "Đồng Hới", "Chu Lai", "Phú Bài", "Thọ Xuân", "Vân Đồn" };
            string[] CodeDataVN = { "VCS","UIH","CAH","VCA", "BMV","DAD","DIN","PXU",
                                    "HPH","HAN","SGN","CXR","VKG","PQC","DLI","VII",
                                    "TBB","VDH","VCL","HUI","THD","VDO" };
            int[] ZipCodeDataVN = { 790000, 820000, 970000, 900000, 630000, 550000, 380000,
                                    600000, 180000, 100000, 700000, 650000, 920000, 920000, 670000, 460000,
                                    620000, 510000, 560000, 530000, 440000 , 200000 };
            for (int num = 0; num < CityDataVN.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbCity",
                 columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                 values: new object[] { CodeDataVN[num], CityDataVN[num], ZipCodeDataVN[num], 190, 1, DateTime.Now, DateTime.Now }
                 );
            };

            //City China
            string[] CityDataChina = { "Bắc Kinh", "Thượng Hải", "Quảng Châu", "Hàng Châu", "Thành Đô","Hồng Kông","Macau" };
            string[] CodeDataChina = { "BJS","SHA","CAN","HGH", "CTU","HKG", "MFM" };
            int[] ZipCodeDataChina = { 100000, 200000 , 510000 , 310000 , 610000 ,518000,519020};

            for (int num = 0; num < CityDataChina.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataChina[num], CityDataChina[num], ZipCodeDataChina[num], 36, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City Dai loan
            string[] CityDataDailoan = { "Đài Bắc", "Cao Hùng"};
            string[] CodeDataDailoan = { "TPE", "KHH", };
            int[] ZipCodeDataDailoan = {100,800 };

            for (int num = 0; num < CityDataDailoan.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataDailoan[num], CityDataDailoan[num], ZipCodeDataDailoan[num], 169, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City Japan
            string[] CityDataJapan = { "Fukuoka", "Nagoya", "Osake", "Tokyo", "Osaka" };
            string[] CodeDataJapan = { "FUK", "NGO", "KIX", "HND", "OSA" };
            int[] ZipCodeDataJapan = {8100000,4500001,5300001,1000001,530001 };

            for (int num = 0; num < CityDataJapan.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataJapan[num], CityDataJapan[num], ZipCodeDataJapan[num], 85, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City korea
            string[] CityDataKorea = { "Busan", "Seoul" };
            string[] CodeDataKorea = { "PUS", "ICN", };
            int[] ZipCodeDataKorea = {600011,100011 };

            for (int num = 0; num < CityDataKorea.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataKorea[num], CityDataKorea[num], ZipCodeDataKorea[num], 91, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City Campuchia
            string[] CityDataCampuchia = { "Phnom Penh", "Siem Reap" };
            string[] CodeDataCampuchia = { "PNH", "REP", };
            int[] ZipCodeDataCampuchia = { 11213, 11213 };

            for (int num = 0; num < CityDataCampuchia.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataCampuchia[num], CityDataCampuchia[num], ZipCodeDataCampuchia[num], 29, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City laos
            string[] CityDataLaos = { "Vientiane", "Luang Phrabang" };
            string[] CodeDataCLaos = { "VTE", "LPQ", };
            int[] ZipCodeDataLaos = { 01003, 01003 };

            for (int num = 0; num < CityDataLaos.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataCLaos[num], CityDataLaos[num], ZipCodeDataLaos[num], 94, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City Indo
            string[] CityDataIndonesia = { "Jakarta", "Bali", "Kuala Namu" };
            string[] CodeDataIndonesia = { "CGK", "DPS", "KNO" };
            int[] ZipCodeDataIndonesia = { 10110 , 20362 , 20362 };

            for (int num = 0; num < CityDataIndonesia.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataIndonesia[num], CityDataIndonesia[num], ZipCodeDataIndonesia[num], 78, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City malaysia
            migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { "KUL", "Kuala Lumpur", 50000, 105, 1, DateTime.Now, DateTime.Now }
                );

            //City Singapore
            migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { "SIN", "Singapore", 339696, 155, 1, DateTime.Now, DateTime.Now }
                );

            //Cyti France
            string[] CityDataFrance = { "Paris", "Marseille","Montpellier","Nice" };
            string[] CodeDataFrance = { "CDG", "MRS","MPL","NCE" };
            int[] ZipCodeDataFrance = { 75001 , 13001 , 34000 , 06300 };

            for (int num = 0; num < CityDataFrance.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataFrance[num], CityDataFrance[num], ZipCodeDataFrance[num], 60, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City Germany
            migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { "FRA", "Frankfurt", 28195, 65, 1, DateTime.Now, DateTime.Now }
                );

            //City England
            migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { "LON", "London", 28195, 183, 1, DateTime.Now, DateTime.Now }
                );

            //City Australia 
            string[] CityDataAustralia = { "Melbourne", "Sydney", "Marrara" };
            string[] CodeDataAustralia = { "MEL", "SYD", "DRW" };
            int[] ZipCodeDataAustralia = { 3000 , 2000 , 0812 };

            for (int num = 0; num < CityDataAustralia.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataAustralia[num], CityDataAustralia[num], ZipCodeDataAustralia[num], 9, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City New Zealand
            string[] CityDataZealand = { "Auckland", "Christchurch", "Wellington" };
            string[] CodeDataZealand = { "AKL", "CHC", "WLG" };
            int[] ZipCodeDataZealand = { 1010, 8011, 6011 };

            for (int num = 0; num < CityDataZealand.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataZealand[num], CityDataZealand[num], ZipCodeDataZealand[num], 9, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City Thailand
            string[] CityDataThailand = { "Băng Cốc", "Phuket" };
            string[] CodeDataThailand = { "BKK", "HKT" };
            int[] ZipCodeDataThailand = { 41380 , 83000 };

            for (int num = 0; num < CityDataThailand.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataThailand[num], CityDataThailand[num], ZipCodeDataThailand[num], 172, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City Nigeria
            migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { "LOS", "Lagos", 104211, 128, 1, DateTime.Now, DateTime.Now }
                );

            //City Russia
            migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { "MOW", "Moscow", 196631, 142, 1, DateTime.Now, DateTime.Now }
                );

            //City South Africa
            string[] CityDataAfrica = { "Cape Town", "Johannesburg" };
            string[] CodeDataAfrica = { "CPT", "JNB" };
            int[] ZipCodeDataAfrica = { 8001, 2001 };

            for (int num = 0; num < CityDataAfrica.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataAfrica[num], CityDataAfrica[num], ZipCodeDataAfrica[num], 160, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City United States
            string[] CityDataUS = {  "Atlanta", "Boston","Worth","Denver","Honolulu",
                                    "Los Angeles","Miami","Minneapolis","New York","Philadephia",
                                    "Portland","San Francisco","Seattle","St Louis" };
            string[] CodeDataUS = { "ATL", "BOS", "DFW", "DEN", "HNL", "LAX", "MIA", "MSP", "JFK", "PHL", "PDX", "SFO", "SEA", "STL" };
            int[] ZipCodeDataUS = {  30303, 02109, 60482, 80204, 96813, 90012, 33128, 55415, 10007, 19107, 97201, 94102, 98104, 63103 };

            for (int num = 0; num < CityDataUS.Length; num++)
            {
                migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { CodeDataUS[num], CityDataUS[num], ZipCodeDataUS[num], 184, 1, DateTime.Now, DateTime.Now }
                );
            };

            //City Myanmar
            migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { "RGN", "Yangon", 196631, 120, 1, DateTime.Now, DateTime.Now }
                );

            //City Czech Republic
            migrationBuilder.InsertData(
                table: "DbCity",
                columns: new[] { "Code", "name", "ZipCode", "DbCountryId", "AirportStatus", "CreatedAt", "UpdatedAt" },
                values: new object[] { "PRG", "Praha", 25765, 46, 1, DateTime.Now, DateTime.Now }
                );
                
        }
        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 0; i < 193; i++)
            {
                migrationBuilder.DeleteData(
                            table: "DbCity",
                            keyColumn: "id",
                            keyValue: i);
            }
        }
    }
}
