using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;


namespace Airplanes.Models
{
    public class DbSeed
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new AirplanesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AirplanesContext>>()))
            {
                // Look for any movies.
                if (context.DbAirport.Any() || context.DbCity.Any() || context.DbAvailableSeat.Any()
                    || context.DbCountry.Any() || context.DbFlight.Any() || context.DbNews.Any()
                    || context.DbOrder.Any() || context.DbPassenger.Any() || context.DbPlane.Any()
                    || context.DbRewardPointsLog.Any() || context.DbRoute.Any() || context.DbTicket.Any()
                    || context.DbTicketClass.Any() || context.DbTransit.Any() )
                {
                    return;   // DB has been seeded
                }

                context.DbAirport.AddRange(
                    new DbAirport
                    {
                        AirportName = "Nội Bài",
                        DbCityId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },

                    new DbAirport
                    {
                        AirportName = "Tân Sân Nhất",
                        DbCityId = 1,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );

                string[] CityData = { "" };
                string[] CodeData = { "" };
                int[] ZipCodeData = {  }; 
                for(int num = 0; num <= CityData.Length; num++  )
                {
                    context.DbCity.AddRange(
                    new DbCity
                    {
                        Code = CodeData[num],
                        Name = CityData[num],
                        ZipCode = ZipCodeData[num],
                        DbCountryId = 1,
                        AirportStatus = AirportStatus.Exist
                    }
                    );
                };
                

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

                    context.DbCountry.AddRange(
                   new DbCountry
                   {
                       CountryName = country,
                       CreatedAt = DateTime.Now,
                       UpdatedAt = DateTime.Now
                   }
                   );
                };

                context.DbPlane.AddRange(
                    new DbPlane
                    {
                        PlaneName = "Airbus A330-300",
                        MadeIn = "Airbus S.A.S.",
                        Image = "~/images/plane/1920px-Usairways_a330-300_n278ay_arp.jpg",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },

                    new DbPlane
                    {
                        PlaneName = "Airbus A350-900XWB",
                        MadeIn = "Airbus S.A.S.",
                        Image = "~/images/plane/800px-A350_First_Flight_-_Low_pass_02.jpg",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },

                    new DbPlane
                    {
                        PlaneName = "Boeing 787-9 Dreamliner",
                        MadeIn = "Boeing Commercial Airplanes.",
                        Image = "~/images/plane/...",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },

                    new DbPlane
                    {
                        PlaneName = "Boeing 737",
                        MadeIn = "Boeing Commercial Airplanes.",
                        Image = "~/images/plane/...",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },

                    new DbPlane
                    {
                        PlaneName = "Boeing 737 MAX",
                        MadeIn = "Boeing Commercial Airplanes.",
                        Image = "~/images/plane/...",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }


                    );
                context.DbFlight.AddRange(
                    new DbFlight
                    {
                        DbRouteId = 1,
                        DbPlaneId = 1,

                    }
                    );

                context.SaveChanges();
            }

        }
    }
}
