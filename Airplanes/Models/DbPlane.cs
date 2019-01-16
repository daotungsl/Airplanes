using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
{
    /// <summary>
    ///  Máy bay
    /// </summary>
    public class DbPlane
    {
        [Key]
        public long Id { get; set; }

        public string PlaneName { get; set; }
        public string MadeIn { get; set; }
        public string Image { get; set; }
        public string UrlTemplate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // 1 Máy bay chứa nhiều chuyến bay
        public ICollection<DbFlight> DbFlights { get; set; }

        public DbPlane()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}