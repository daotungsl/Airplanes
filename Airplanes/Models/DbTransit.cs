using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplanes.Models
{
    public class DbTransit
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("DbFlight")]
        public long DbFlightId { get; set; }
        public DbFlight DbFlight { get; set; }

        [ForeignKey("DbAirPort")]
        public long DbAirportId { get; set; }
        public DbAirport DbAirPort { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Delay Time")]
        public int DelayTime { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Note")]
        public string Note { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        
        

        public DbTransit()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}