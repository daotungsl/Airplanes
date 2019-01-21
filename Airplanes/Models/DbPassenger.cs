using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airplanes.Models.Custom;

namespace Airplanes.Models
{
    /// <summary>
    /// Thông tin của hành khách được điền trên vé
    /// </summary>
    public class DbPassenger
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("AirplanesUser")]
        public string UId { get; set; }
        public AirplanesUser AirplanesUser { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Lien Ket 1 vé bay tương ứng với 1 khách hàng trong 1 chuyến bay
        public DbTicket DbTicket { get; set; }

        

        public DbPassenger()
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }

    public enum Gender
    {
        Mr = 1,
        Miss = 0
    }
}