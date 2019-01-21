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

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Plane Name")]
        public string PlaneName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Made in")]
        public string MadeIn { get; set; }

        [Required]
        [Url]
        [DataType(DataType.Text)]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [Required]
        [Url]
        [DataType(DataType.Text)]
        [Display(Name = "Url Template")]
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