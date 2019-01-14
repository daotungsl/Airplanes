using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
{
    /// <summary>
    /// Chỗ ngồi khả dụng của 1 hạng vé trên 1 chuyến bay
    /// </summary>
    public class DbAvailableSeat
    {
        [Key]
        public long Id { get; set; }

        // ID chuyến bay
        public long DbFlightId { get; set; }

        // ID Hạng vé
        public long DbTicketClassId { get; set; }
        public int Quantity { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public DbFlight DbFlight { get; set; }
        public DbTicketClass DbTicketClass { get; set; }

        public DbAvailableSeat()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
        }
    }
}
