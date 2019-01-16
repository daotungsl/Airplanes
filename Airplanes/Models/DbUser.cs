using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace AirlineTicketResourceServer.Models
{
    /// <summary>
    /// Thông tin của 1 user đã đăng ký và điền đầy đủ thông tin
    /// </summary>
    public class DbUser
    {
        [Key]
        public long Id { get; set; }
        public long UId { get; set; }

        // Thêm các entity của bảng Account vào trong User
        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string Salt { get; set; }
        
        [Required]
        [StringLength(30)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }


        public UserGender Gender { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 9)]
        [Display(Name = "ID Number")]
        public string IdNumber { get; set; }
        [Required]
        [StringLength(20)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail address")]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }

        // Điểm tích lũy khi mua vé hoặc hủy vé sẽ thay đổi
        public int RewardPoints { get; set; }

        public EmailVerifyStatus EmailVerifyStatus { get; set; }
        public PhoneVerifyStatus PhoneVerifyStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public AccountStatus Status { get; set; }

        public ICollection<DbRewardPointsLog> DbRewardPointsLogs { get; set; }

        public DbUser()
        {
            UId = DateTime.Now.Ticks;
            RewardPoints = 0;
            EmailVerifyStatus = EmailVerifyStatus.Deactivated;
            PhoneVerifyStatus = PhoneVerifyStatus.Unconfirmed;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            Status = AccountStatus.Activated;
        }
    }

    public enum UserGender
    {
        Female = 0,
        Male = 1,
        Other = 2
    }

    public enum EmailVerifyStatus
    {
        Activated = 1,
        Deactivated = 0
    }

    public enum PhoneVerifyStatus
    {
        Confirmed = 1,
        Unconfirmed = 0
    }

    public enum AccountStatus
    {
        Activated = 1,
        Deactivated = 0,
        Blocked = 2
    }
}
