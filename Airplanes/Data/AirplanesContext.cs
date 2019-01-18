using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Airplanes.Models;

namespace Airplanes.Models
{
    public class AirplanesContext : DbContext
    {
        public AirplanesContext (DbContextOptions<AirplanesContext> options)
            : base(options)
        {
        }

        public DbSet<Airplanes.Models.DbUser> DbUser { get; set; }
        
    }
}
