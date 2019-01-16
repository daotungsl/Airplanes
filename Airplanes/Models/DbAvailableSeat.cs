using System;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DbFlight DbFlight { get; set; }
        public DbTicketClass DbTicketClass { get; set; }

        public DbAvailableSeat()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}