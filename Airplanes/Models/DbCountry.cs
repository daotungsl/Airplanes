using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
{
    /// <summary>
    /// Quốc gia
    /// </summary>
    public class DbCountry
    {
        [Key]
        public long Id { get; set; }
        public string CountryName { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<DbAirPort> DbAirPorts { get; set; }

        public ICollection<DbCity> DbCities { get; set; }

        public DbCountry()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
