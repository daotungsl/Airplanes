using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplanes.Models
{
    /// <summary>
    /// Thông tin chi tiết về 1 sân bay
    /// </summary>
    public class DbAirport
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Airport Name")]
        public string AirportName { get; set; }

        // ID thành phố có sân bay này
        [ForeignKey("DbCity")]
        public long DbCityId { get; set; }
        public DbCity DbCity { get; set; }

        //[ForeignKey("DbCountry")]
        //public long CountryId { get; set; }
        //public DbCountry DbCountry { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public DbAirport()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}