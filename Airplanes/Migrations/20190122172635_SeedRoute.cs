using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Route Viet Nam 
            string[] CodeDataVN = { "VCS","UIH","CAH","VCA", "BMV","DAD","DIN","PXU",
                                    "HPH","HAN","SGN","CXR","VKG","PQC","DLI","VII",
                                    "TBB","VDH","VCL","HUI","THD","VDO" };
            for (int num = 0; num < CodeDataVN.Length; num++)
            {
                foreach (string RouteData in CodeDataVN)
                {
                    if (CodeDataVN[num] != RouteData)
                    {
                        migrationBuilder.InsertData(
                     table: "DbRoute",
                     columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
                     values: new object[] { CodeDataVN[num], RouteData, DateTime.Now, DateTime.Now }
                     );
                    }

                }

            };

            // Route from HAN to the world 
            string[] CodeDataHAN = { "BKK","HKT","RGN", "REP","KUL","VTE","LPQ",
                                    "BJS", "SHA","CAN","HGH","CTU","HKG","MFM","KHH","SIN","OSA",
                                     "FUK","NGO","HND","TPE","PUS","ICN","MOW","LON","CDG"};

            foreach (string RouteData in CodeDataHAN)
            {
                //From HAN
                migrationBuilder.InsertData(
             table: "DbRoute",
             columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
             values: new object[] { "HAN", RouteData, DateTime.Now, DateTime.Now }
             );
                //To HAN
                migrationBuilder.InsertData(
                table: "DbRoute",
                columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
                values: new object[] { RouteData, "HAN", DateTime.Now, DateTime.Now }
                );

            }

            // Route from SGN to the world 
            string[] CodeDataSGN = { "BKK","HKT","RGN", "REP","KUL","VTE","LPQ", "MEL","SYD",
                                    "BJS", "SHA","CAN","HGH","CTU","HKG","MFM","KHH","SIN","OSA",
                                     "FUK","NGO","HND","TPE","PUS","ICN","MOW","LON","CDG"};

            foreach (string RouteData in CodeDataSGN)
            {
                //From SGN
                migrationBuilder.InsertData(
             table: "DbRoute",
             columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
             values: new object[] { "SGN", RouteData, DateTime.Now, DateTime.Now }
             );
                //To SGN
                migrationBuilder.InsertData(
                table: "DbRoute",
                columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
                values: new object[] { RouteData, "SGN", DateTime.Now, DateTime.Now }
                );

            }

            // Route from PQC to the world 
            string[] CodeDataPQC = { "BKK", "ICN", "KUL", "CAN" };

            foreach (string RouteData in CodeDataPQC)
            {
                //From PQC
                migrationBuilder.InsertData(
             table: "DbRoute",
             columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
             values: new object[] { "PQC", RouteData, DateTime.Now, DateTime.Now }
             );
                //To PQC
                migrationBuilder.InsertData(
                table: "DbRoute",
                columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
                values: new object[] { RouteData, "PQC", DateTime.Now, DateTime.Now }
                );

            }

            // Route from DAD to the world 
            string[] CodeDataDAD = { "BKK", "SIN", "HKG", "ICN","PUS","SHA","CAN","HGH","CTU","REP","TPE",
                                     "MFM","KUL","OSA","HND"};

            foreach (string RouteData in CodeDataDAD)
            {
                //From DAD
                migrationBuilder.InsertData(
             table: "DbRoute",
             columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
             values: new object[] { "DAD", RouteData, DateTime.Now, DateTime.Now }
             );
                //To DAD
                migrationBuilder.InsertData(
                table: "DbRoute",
                columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
                values: new object[] { RouteData, "DAD", DateTime.Now, DateTime.Now }
                );

            }

            // Route from ICN to the world 
            string[] CodeDataKorea = { "SHA", "CAN", "HGH", "HKG","MFM","FUK","NGO","KIX","HND",
                                        "OSA","KUL","TPE","KHH","MOW","HKT","BKK","SIN","JNB","ATL",
                                        "BOS","DFW","DEN","HNL","LAX","MIA","MSP","FRA","SYD","VTE"};

            foreach (string RouteData in CodeDataKorea)
            {
                //From ICN
                migrationBuilder.InsertData(
             table: "DbRoute",
             columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
             values: new object[] { "ICN", RouteData, DateTime.Now, DateTime.Now }
             );
                //To ICN
                migrationBuilder.InsertData(
                table: "DbRoute",
                columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
                values: new object[] { RouteData, "ICN", DateTime.Now, DateTime.Now }
                );

            }

            // Route from BJS to the world 
            string[] CodeDataBJS = { "LON", "MEL", "SYD", "MOW","MFM","HKT","NGO","KIX","HND",
                                        "OSA","KUL","TPE","KHH","MOW","HKT","BKK","SIN","JNB","ATL",
                                        "BOS","DFW","DEN","HNL","LAX","MIA","MSP","FRA","SYD","VTE"};

            foreach (string RouteData in CodeDataBJS)
            {
                //From ICN
                migrationBuilder.InsertData(
             table: "DbRoute",
             columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
             values: new object[] { "BJS", RouteData, DateTime.Now, DateTime.Now }
             );
                //To ICN
                migrationBuilder.InsertData(
                table: "DbRoute",
                columns: new[] { "FromAirport", "ToAirport", "CreatedAt", "UpdatedAt" },
                values: new object[] { RouteData, "BJS", DateTime.Now, DateTime.Now }
                );

            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
