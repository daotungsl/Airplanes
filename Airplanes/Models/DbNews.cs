using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
{
    /// <summary>
    /// Các tin tức mới về việc khởi hành của các chuyến may hay thông tin delay
    /// </summary>
    public class DbNews
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
    }
}
