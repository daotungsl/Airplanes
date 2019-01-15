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
        [StringLength(100)]
        public string Password { get; set; }

        public string Salt { get; set; }
        
        
        public string FullName { get; set; }
        public UserGender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string IdNumber { get; set; }
        [Required]
        [StringLength(20)]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }

        // Điểm tích lũy khi mua vé hoặc hủy vé sẽ thay đổi
        public int RewardPoints { get; set; }

        public EmailVerifyStatus EmailVerifyStatus { get; set; }
        public PhoneVerifyStatus PhoneVerifyStatus { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public AccountStatus Status { get; set; }

        public ICollection<DbRewardPointsLog> DbRewardPointsLogs { get; set; }

        public DbUser()
        {
            UId = DateTime.Now.Ticks;
            RewardPoints = 0;
            EmailVerifyStatus = EmailVerifyStatus.Deactivated;
            PhoneVerifyStatus = PhoneVerifyStatus.Unconfirmed;
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
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
