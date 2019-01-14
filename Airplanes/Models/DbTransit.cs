using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
{
    public class DbTransit
    {
        [Key]
        public long Id { get; set; }
        public long DbFlightId { get; set; }
        public long DbAirportId { get; set; }
        public int DelayTime { get; set; }
        public string Note { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public DbTransit()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
        }
    }
}
