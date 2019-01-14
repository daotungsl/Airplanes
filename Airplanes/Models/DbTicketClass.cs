using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
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

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public DbTicketClass()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = DateTime.Now.Ticks;
        }
    }
}
