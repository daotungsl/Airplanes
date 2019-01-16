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

        // ID Đường bay
        public long DbRouteId { get; set; }

        // ID Máy bay sử dụng cho chuyến này
        public long DbPlaneId { get; set; }

        public DateTime FlightTime { get; set; }
        public int TimeOfTransit { get; set; }
        public int FlightDuration { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public FlightStatus Status { get; set; }

        public ICollection<DbAvailableSeat> AvailableSeats { get; set; }
        public DbPlane DbPlane { get; set; }
        public DbRoute DbRoute { get; set; }

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