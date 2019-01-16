using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
{
    /// <summary>
    /// Hạng vé máy bay
    /// </summary>
    public class DbTicketClass
    {
        [Key]
        public long Id { get; set; }

        public string TicketClassName { get; set; }

        // 1 hạng vé chứa nhiều vé ở các chuyến bay khác nhau
        public ICollection<DbTicket> DbTickets { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DbTicketClass()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}