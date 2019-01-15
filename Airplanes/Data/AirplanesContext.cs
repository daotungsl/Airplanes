using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirlineTicketResourceServer.Models;

namespace Airplanes.Models
{
    public class AirplanesContext : DbContext
    {
        public AirplanesContext (DbContextOptions<AirplanesContext> options)
            : base(options)
        {
        }

        public DbSet<AirlineTicketResourceServer.Models.DbUser> DbUser { get; set; }
        
    }
}
