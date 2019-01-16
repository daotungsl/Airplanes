using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
{
    /// <summary>
    /// Đường bay từ sân nào tới sân nào
    /// </summary>
    public class DbRoute
    {
        [Key]
        public long Id { get; set; }

        public string FromAirport { get; set; }
        public string ToAirport { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // 1 đường bay có nhiều chuyến bay
        public ICollection<DbFlight> DbFlights { get; set; }

        public DbRoute()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}