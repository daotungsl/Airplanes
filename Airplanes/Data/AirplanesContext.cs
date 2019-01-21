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



        public DbSet<Airplanes.Models.DbAirPort> DbAirPorts { get; set; }
        public DbSet<Airplanes.Models.DbCity> DbCities { get; set; }
        public DbSet<Airplanes.Models.DbAvailableSeat> DbAvailableSeats { get; set; }
        public DbSet<Airplanes.Models.DbCountry> DbCountries { get; set; }
        public DbSet<Airplanes.Models.DbFlight> DbFlights { get; set; }
        public DbSet<Airplanes.Models.DbOrder> DbOrders { get; set; }
        public DbSet<Airplanes.Models.DbPassenger> DbPassengers { get; set; }
        public DbSet<Airplanes.Models.DbPlane> DbPlanes { get; set; }
        public DbSet<Airplanes.Models.DbRewardPointsLog> DbRewardPointsLogs { get; set; }
        public DbSet<Airplanes.Models.DbRoute> DbRoutes { get; set; }
        public DbSet<Airplanes.Models.DbTicket> DbTickets { get; set; }
        public DbSet<Airplanes.Models.DbTicketClass> DbTicketClasses { get; set; }
        public DbSet<Airplanes.Models.DbTransit> DbTransits { get; set; }
        public DbSet<Airplanes.Models.DbUser> DbUsers { get; set; }









        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
