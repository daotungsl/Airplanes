using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airplanes.Models.Custom;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Airplanes.Models
{
    public class AirplanesContext : IdentityDbContext<AirplanesUser>
    {
        public AirplanesContext(DbContextOptions<AirplanesContext> options)
            : base(options)
        {
        }
        public DbSet<Airplanes.Models.DbNews> DbNews { get; set; }

        public DbSet<Airplanes.Models.DbRewardPointsLog> DbRewardPointsLog { get; set; }

        public DbSet<Airplanes.Models.DbPassenger> DbPassenger { get; set; }

        public DbSet<Airplanes.Models.DbRoute> DbRoute { get; set; }

        public DbSet<Airplanes.Models.DbPlane> DbPlane { get; set; }

        public DbSet<Airplanes.Models.DbCountry> DbCountry { get; set; }

        public DbSet<Airplanes.Models.DbCity> DbCity { get; set; }

        public DbSet<Airplanes.Models.DbAirport> DbAirport { get; set; }

        public DbSet<Airplanes.Models.DbTicketClass> DbTicketClass { get; set; }

        public DbSet<Airplanes.Models.DbFlight> DbFlight { get; set; }

        public DbSet<Airplanes.Models.DbTransit> DbTransit { get; set; }

        public DbSet<Airplanes.Models.DbAvailableSeat> DbAvailableSeat { get; set; }

        public DbSet<Airplanes.Models.DbOrder> DbOrder { get; set; }

        public DbSet<Airplanes.Models.DbTicket> DbTicket { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
