using System;
using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
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

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DbNews()
        {
            Date = DateTime.Now;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}