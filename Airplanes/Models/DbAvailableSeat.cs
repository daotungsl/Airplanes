using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("DbFlight")]
        public long DbFlightId { get; set; }
        public DbFlight DbFlight { get; set; }

        // ID Hạng vé
        [ForeignKey("DbTicketClass")]
        public long TicketClassId { get; set; }
        public DbTicketClass DbTicketClass { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Rest Ticket")]
        public int RestTicket { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        
        

        public DbAvailableSeat()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}