using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
{
    public class DbOrder
    {
        [Key]
        public long Id { get; set; }
        public long UId { get; set; }

        // 1 Order có thể có 1 hoặc nhiều vé bay
        public ICollection<DbTicket> DbTickets { get; set; }
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
        public OrderStatus Status { get; set; }
    }

    public enum OrderStatus
    {
        Paid = 1,
        Reservation = 0
    }
}
