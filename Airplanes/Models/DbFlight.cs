using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
{
    /// <summary>
    /// Chuyến Bay
    /// </summary>
    public class DbFlight
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [Display(Name = "Roll Number")]
        public string RollNumber { get; set; }

        // ID Đường bay
        public long DbRouteId { get; set; }

        // ID Máy bay sử dụng cho chuyến này
        public long DbPlaneId { get; set; }

        [Required]
        [Display(Name = "Flight Time")]
        public DateTime FlightTime { get; set; }

        [Required]
        [Display(Name = "Time of transit")]
        public int TimeOfTransit { get; set; }

        [Required]
        [Display(Name = "Flight Duration")]
        public int FlightDuration { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public FlightStatus Status { get; set; }

        public ICollection<DbAvailableSeat> AvailableSeats { get; set; }
        public DbPlane DbPlane { get; set; }
        public DbRoute DbRoute { get; set; }
        public DbTransit DbTransit { get; set; }
        public ICollection<DbTicket> DbTickets { get; set; }

        public DbFlight()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = FlightStatus.Available;
        }
    }

    public enum FlightStatus
    {
        Available = 0,
        TakeOff = 1,
        Land = 2
    }
}