using System;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
{
    /// <summary>
    /// Lịch sử điểm tích tũy khi mua hoặc hủy vé
    /// </summary>
    public class DbRewardPointsLog
    {
        [Key]
        public long Id { get; set; }

        public long UId { get; set; }
        public string NameLog { get; set; }
        public int Points { get; set; }
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; }

        public DbUser DbUser { get; set; }

        public DbRewardPointsLog()
        {
            CreatedAt = DateTime.Now;
        }
    }
}