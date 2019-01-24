using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Airplanes.Models
{
    /// <summary>
    /// Thông tin 1 vé: hạng vé, chuyến bay, hành khách
    /// </summary>
    public class DbTicket
    {
        [Key]
        public long Id { get; set; }

        // 1 Vé chỉ tương ứng với 1 lần order
        [ForeignKey("DbOrder")]
        [Display(Name = "Order Id")]
        public long DbOrderId { get; set; }
        public DbOrder DbOrder { get; set; }
        // 1 vé chỉ thuộc 1 hạng vé
        [ForeignKey("DbTicketClass")]
        [Display(Name = "Ticket Class")]
        public long DbTicketClassId { get; set; }
        public DbTicketClass DbTicketClass { get; set; }
        // 1 vé chỉ thuộc 1 chuyến bay
        [ForeignKey("DbFlight")]
        [Display(Name = "Flight Code")]
        public long DbFlightId { get; set; }
        public DbFlight DbFlight { get; set; }
        // 1 vé chỉ được ghi tên 1 hành khách
        [ForeignKey("DDbPassenger")]
        [Display(Name = "Passenger Name")]
        public long DbPassengerId { get; set; }
        public DbPassenger DbPassenger { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ticket Price")]
        public int Price { get; set; }

        //public int Quantity { get; set; }

        [Display(Name = "Booking At")]
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TicketStatus Status { get; set; }

        // Lien Ket

        public DbTicket()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = TicketStatus.Sold;
        }
    }

    public enum TicketStatus
    {
        Cancel = 0,
        Sold = 1,
        Hold = 2
    }
}
