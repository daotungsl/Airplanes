using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Airplanes.Models.Custom;

namespace Airplanes.Models
{
    /// <summary>
    /// Lịch sử điểm tích tũy khi mua hoặc hủy vé
    /// </summary>
    public class DbRewardPointsLog
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("AirplanesUser")]
        public string UId { get; set; }
        public AirplanesUser AirplanesUser { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Name Log")]
        public string NameLog { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Points")]
        public int Points { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Text)]
        [Display(Name = "Note")]
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }

        //public DbUser DbUser { get; set; }
        

        public DbRewardPointsLog()
        {
            CreatedAt = DateTime.Now;
        }
    }
}