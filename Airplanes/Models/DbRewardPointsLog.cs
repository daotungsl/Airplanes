using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
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
        public long CreatedAt { get; set; }

        public DbUser DbUser { get; set; }

        public DbRewardPointsLog()
        {
            CreatedAt = DateTime.Now.Ticks;
        }
    }
}
