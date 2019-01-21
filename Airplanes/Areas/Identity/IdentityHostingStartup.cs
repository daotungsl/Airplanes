using System;
using Airplanes.Models;
using Airplanes.Models.Custom;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Airplanes.Areas.Identity.IdentityHostingStartup))]
namespace Airplanes.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AirplanesContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AirplanesContext")));

                //services.AddDefaultIdentity<AirplanesUser>()
                //    .AddEntityFrameworkStores<AirplanesContext>();
            });
        }
    }
}