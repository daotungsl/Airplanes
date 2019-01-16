using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Airplanes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Airplanes.Models
{
    public class AirplanesContext : IdentityDbContext
    {
        public AirplanesContext (DbContextOptions<AirplanesContext> options)
            : base(options)
        {
        }

        public DbSet<Airplanes.Models.DbUser> DbUser { get; set; }
        
    }
}
