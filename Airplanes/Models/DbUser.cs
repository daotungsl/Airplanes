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
        public int RewardPoints { get; set; }
        public EmailVerifyStatus EmailVerifyStatus { get; set; }
        public PhoneVerifyStatus PhoneVerifyStatus { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public ICollection<DbRewardPointsLog> DbRewardPointsLogs { get; set; }

        public DbUser()
        {
            RewardPoints = 0;
            EmailVerifyStatus = EmailVerifyStatus.Deactivated;
            PhoneVerifyStatus = PhoneVerifyStatus.Unconfirmed;
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
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
}
