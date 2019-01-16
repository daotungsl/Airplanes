using System;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
{
    /// <summary>
    /// Thông tin chi tiết về 1 sân bay
    /// </summary>
    public class DbAirPort
    {
        [Key]
        public long Id { get; set; }

        public string AirportName { get; set; }

        // ID Khu vực có sân bay này
        public long DbCityId { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DbCity DbCity { get; set; }

        public DbAirPort()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}