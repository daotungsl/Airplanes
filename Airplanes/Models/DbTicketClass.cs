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

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Ticket Class Name")]
        public string TicketClassName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Price")]
        public int Price { get; set; }

        // 1 hạng vé chứa nhiều vé ở các chuyến bay khác nhau
        public ICollection<DbTicket> DbTickets { get; set; }
        public ICollection<DbAvailableSeat> DbAvailableSeats { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DbTicketClass()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}