using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
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

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public FlightStatus Status { get; set; }
        
        public ICollection<DbAvailableSeat> AvailableSeats { get; set; }
        public DbPlane DbPlane { get; set; }
        public DbRoute DbRoute { get; set; }

        public DbFlight()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
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
