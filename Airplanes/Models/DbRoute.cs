using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
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

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        // 1 đường bay có nhiều chuyến bay
        public ICollection<DbFlight> DbFlights { get; set; }

        public DbRoute()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
        }
    }
}
