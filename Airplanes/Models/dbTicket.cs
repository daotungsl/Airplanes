using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
{
    /// <summary>
    /// Thông tin 1 vé: hạng vé, chuyến bay, hành khách
    /// </summary>
    public class DbTicket
    {
        [Key]
        public long Id { get; set; }

        // 1 Vé chỉ tương ứng với 1 lần order
        public long DbOrderId { get; set; }

        // 1 vé chỉ thuộc 1 hạng vé
        public long DbTicketClassId { get; set; }

        // 1 vé chỉ thuộc 1 chuyến bay
        public long DbFlightId { get; set; }

        // 1 vé chỉ được ghi tên 1 hành khách
        public long DbPassengerId { get; set; }
        public int Price { get; set; }

        //public int Quantity { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public TicketStatus Status { get; set; }


        // Lien Ket
        public DbTicketClass DbTicketClass { get; set; }
        public DbPassenger DbPassenger { get; set; }
        public DbOrder DbOrder { get; set; }
        

        public DbTicket()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
        }
    }

    public enum TicketStatus
    {
        Cancel = 0,
        Sold = 1,
        Hold = 2
    }
}
