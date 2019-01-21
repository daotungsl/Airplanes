using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Airplanes.Migrations
{
    public partial class SeedDbCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string[] CountryData = { "Afghanistan", "Albania", "Algeria", "Andorra", "Angola",
                                        "Antigua & Barbuda", "Argentina", "Armenia", "Australia", "Austria",
                                        "Azerbaijan", "The Bahamas", "Bahrain", "Bangladesh", "Barbados",
                                        "Belarus", "Belgium", "Belize", "Benin", "Bhutan",
                                        "Bolivia", "Bosnia & Herzegovina", "Botswana", "Brazil", "Brunei",
                                        "Bulgaria", "Burkina Faso", "Burundi", "Combodia", "Cameroon",
                                        "Canada", "Cape Verde", "Central African Republic", "Chad", "Chile",
                                        "China", "Colombia", "Comoros", "Republic of the Congo", "Democratic Republic of the Congo",
                                        "Costa Rica", "Ivory Coast", "Croatia", "Cuba", "Cyprus",
                                        "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic",
                                        "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea",
                                        "Estonia", "Ethiopia", "Eritrea", "Fiji", "France",
                                        "Finland", "Gabon", "The Gambia", "Georgia", "Germany",
                                        "Ghana", "Greece", "Grenada", "Guatemala", "Guinea",
                                        "Guinea Bissau", "Guyana", "Haiti", "Honduras", "Hungary",
                                        "Iceland", "India", "Indonesia", "Iran", "Iraq",
                                        "Ireland", "Israel", "Italy", "Jamaica", "Japan",
                                        "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, North",
                                        "Korea, South", "Kuwait", "Kyrgyzstan", "Laos",
                                        "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya",
                                        "Liechtenstein", "Luxembourg", "Macedonia", "Madagascar", "Malawi",
                                        "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands",
                                        "Mauritania", "Mauritius", "Mexico", "Federated States of Micronesia", "Moldova",
                                        "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique",
                                        "Burma", "Namibia", "Nauru", "Nepal", "Netherlands",
                                        "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway",
                                        "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea",
                                        "Paraguay", "Peru", "Philippines", "Poland", "Portugal",
                                        "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis",
                                        "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe",
                                        "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone",
                                        "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia",
                                        "South Africa", "Spain", "Sri Lanka", "Sudan", "Suriname",
                                        "Swaziland", "Sweden", "Sweden", "Syria", "Taiwan",
                                        "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga",
                                        "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu",
                                        "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States",
                                        "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City (Holy See)", "Venezuela",
                                        "Vietnam", "Yemen", "Zambia", "Zimbabwe" };
            foreach (string country in CountryData)
            {
                migrationBuilder.InsertData(
               table: "DbCountry",
               columns: new[] { "CountryName", "CreatedAt", "UpdatedAt" },
              values: new object[] { country, DateTime.Now, DateTime.Now }
                );
            };

            


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            for (int i = 0; i < 193; i++)
            {
                migrationBuilder.DeleteData(
                            table: "DbCountry",
                            keyColumn: "id",
                            keyValue: i);
            }

        }
    }
}
