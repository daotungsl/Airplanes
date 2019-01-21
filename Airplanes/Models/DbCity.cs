using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Airplanes.Models
{
    /// <summary>
    /// Thông tin chi tiết về 1 thành phố có hoặc không có sân bay
    /// </summary>
    public class DbCity
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "City Code")]
        public string Code { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "City Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Zip Code")]
        public long ZipCode { get; set; }

        // Thành phố trực thuộc quốc gia nào
        [ForeignKey("DbCountry")]
        public long DbCountryId { get; set; }
        public DbCountry DbCountry { get; set; }

        // Thành phố sở hữu sân bay nào
        public DbAirport DbAirPort { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AirportStatus AirportStatus { get; set; }

        public DbCity()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            AirportStatus = AirportStatus.Exist;
        }
    }

    public enum AirportStatus
    {
        Exist = 1,
        NotExist = 0
    }
}