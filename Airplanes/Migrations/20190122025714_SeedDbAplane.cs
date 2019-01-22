using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedDbAplane : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] PlaneName = { "Airbus A330-300", "Airbus A350-900XWB", "Boeing 787-9 Dreamliner", "Boeing 737", "Boeing 737 MAX",
                                    "Boeing 777","Airbus A321","Airbus A380", };
            string[] MadeIn = { "Airbus S.A.S","Airbus S.A.S","Boeing BCA",
                                "Boeing BCA", "Boeing BCA",
                                "Boeing BCA","Airbus S.A.S","Airbus S.A.S" };
            string[] Image = { "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Usairways_a330-300_n278ay_arp.jpg/1280px-Usairways_a330-300_n278ay_arp.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/A350_First_Flight_-_Low_pass_02.jpg/1024px-A350_First_Flight_-_Low_pass_02.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3b/All_Nippon_Airways_Boeing_787-8_Dreamliner_JA801A_OKJ.jpg/1024px-All_Nippon_Airways_Boeing_787-8_Dreamliner_JA801A_OKJ.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/2/26/AirBerlin_B737-800_D-ABBF_MUC_2008-08-13.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/WS_YYC_737_MAX_1.jpg/1024px-WS_YYC_737_MAX_1.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Boeing_777-219ER_ZK-OKA_Air_New_Zealand_(7031891827).jpg/1024px-Boeing_777-219ER_ZK-OKA_Air_New_Zealand_(7031891827).jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/7/72/D-AIAF_(19552328044).jpg/1024px-D-AIAF_(19552328044).jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Emirates_Airbus_A380-861_A6-EER_MUC_2015_02.jpg/1920px-Emirates_Airbus_A380-861_A6-EER_MUC_2015_02.jpg" };
            string[] UrlTemplate = {"https://upload.wikimedia.org/wikipedia/commons/thumb/d/d9/Usairways_a330-300_n278ay_arp.jpg/1280px-Usairways_a330-300_n278ay_arp.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/A350_First_Flight_-_Low_pass_02.jpg/1024px-A350_First_Flight_-_Low_pass_02.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3b/All_Nippon_Airways_Boeing_787-8_Dreamliner_JA801A_OKJ.jpg/1024px-All_Nippon_Airways_Boeing_787-8_Dreamliner_JA801A_OKJ.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/2/26/AirBerlin_B737-800_D-ABBF_MUC_2008-08-13.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/4/40/WS_YYC_737_MAX_1.jpg/1024px-WS_YYC_737_MAX_1.jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Boeing_777-219ER_ZK-OKA_Air_New_Zealand_(7031891827).jpg/1024px-Boeing_777-219ER_ZK-OKA_Air_New_Zealand_(7031891827).jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/7/72/D-AIAF_(19552328044).jpg/1024px-D-AIAF_(19552328044).jpg",
                                "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d3/Emirates_Airbus_A380-861_A6-EER_MUC_2015_02.jpg/1920px-Emirates_Airbus_A380-861_A6-EER_MUC_2015_02.jpg" };

            for (int num = 0; num < PlaneName.Length; num++)
            {
                migrationBuilder.InsertData(
                 table: "DbPlane",
                 columns: new[] { "PlaneName", "MadeIn", "Image", "UrlTemplate", "CreatedAt", "UpdatedAt" },
                 values: new object[] { PlaneName[num], MadeIn[num], Image[num], UrlTemplate[num], DateTime.Now, DateTime.Now }
                 );
            };
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
