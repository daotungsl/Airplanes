using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airplanes.Models.Custom;

namespace Airplanes.Models
{
    public class DbOrder
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("AirplanesUser")]
        public string UId { get; set; }
        public AirplanesUser AirplanesUser { get; set; }

        [Required]
        [Display(Name = "Adult")]
        public int Adult { get; set; }

        [Required]
        [Display(Name = "Child")]
        public int Child { get; set; }
        

        // 1 Order có thể có 1 hoặc nhiều vé bay
        public ICollection<DbTicket> DbTickets { get; set; }

        [Required]
        [Display(Name = "Quantity Ticket")]
        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public OrderStatus Status { get; set; }

        public DbOrder()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = OrderStatus.Paid;
        }
        
    }

    public enum OrderStatus
    {
        Paid = 1,
        Reservation = 0
    }
}