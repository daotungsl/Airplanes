using System;
using System.Collections.Generic;
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

        // Thêm các thuộc tính validate có sẵn
        [Required] // không trống
        [StringLength(100, ErrorMessage = "Tên tiêu đề chỉ từ 10-100 kí tự", MinimumLength = 10)] // độ dài tối đa và tối thiểu
        [DataType(DataType.Text)]
        public string Title { get; set; }
        [Required]
        [StringLength(1000,ErrorMessage = "Nội dung bài chỉ từ 50-1000 kí tự" ,MinimumLength = 50)]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }

        // Riêng datetime thì chỉ cần date thôi. ko cần HH-mm đằng sau
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of event")] // cái ngày xảy ra sự kiện này
        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DbNews()
        {
            //Date = DateTime.Now;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}