﻿using Airplanes.Models;
using Airplanes.Models.Admin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Airplanes.Models.Custom;
using Microsoft.AspNetCore.Identity;

namespace Airplanes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddIdentity<AirplanesUser, IdentityRole>()
                .AddEntityFrameworkStores<AirplanesContext>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            services.AddDbContext<AirplanesContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AirplanesContext")));
            
            

            //services.AddDbContext<AirplanesContextResource>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("AirplanesContextResource")));

            //services.AddDbContext<AirplanesContext>(options =>
            //        options.UseSqlServer(Configuration.GetConnectionString("AirplanesContext")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env/*, RoleManager<IdentityRole> roleManager*/)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            //await Initializer.initial(roleManager);
        }
    }
}