using System;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
{
    public class DbTransit
    {
        [Key]
        public long Id { get; set; }

        public long DbFlightId { get; set; }
        public long DbAirportId { get; set; }
        public int DelayTime { get; set; }
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