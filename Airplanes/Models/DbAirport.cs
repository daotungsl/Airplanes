using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
{
    /// <summary>
    /// Thông tin chi tiết về 1 sân bay
    /// </summary>
    public class DbAirPort
    {
        [Key]
        public long Id { get; set; }
        public string AirportName { get; set; }

        // ID Khu vực có sân bay này
        public long DbCityId { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        public DbCity DbCity { get; set; }

        public DbAirPort()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
        }
    }
}
