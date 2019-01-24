using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Airplanes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Airplanes.Models
{
    public class SeedNews
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context =
                new AirplanesContext(serviceProvider.GetRequiredService<DbContextOptions<AirplanesContext>>()))
            {
                if (context.DbNews.Any())
                {
                    return;
                }

                context.DbNews.AddRange(
                    new DbNews
                    {
                        Title = "Bay khắp Việt Nam “Kết nối yêu thương – Yêu là phải tới” với triệu vé Vietjet giá từ 0 đồng",
                        Author = "Xuân Hải",
                        Content = "(EagleAirline, TP.HCM, 26/01/2019) – Tiếp tục chuỗi ưu đãi “khủng” của chương trình lớn nhất khu vực “Kết nối yêu thương – Yêu là phải tới”, EagleAirline dành tặng 1,8 triệu vé siêu tiết kiệm giá chỉ từ 0 đồng (*) vào 03 ngày vàng 26/01 - 28/01/2019 tại website www.vietjetair.com." + "</br>" + "Vé khuyến mại áp dụng trên tất cả đường bay trong nước vào khung giờ vàng 12h – 14h cho thời gian bay từ 16/02/2019 đến 31/12/2019." + "</br>" + "Những bài viết ý nghĩa, chân thành nhất nhận được vé máy bay miễn phí khứ hồi tham gia hành trình kết nối yêu thương vòng quanh châu Á với nhiều thú vị, độc đáo chỉ có trên tàu bay Vietjet như gặp gỡ cosplay Nhật Bản, tràn ngập quà tặng đêm Giáng sinh, đón giao thừa ở độ cao 10.000 mét, hay tham gia các vũ hội âm nhạc… Vietjet luôn đồng hành cùng bạn xuyên suốt hành trình với nhiều niềm vui ý nghĩa, hoạt động thiện nguyện, kết nối con người đến vùng trời mơ ước.",
                        Date = Convert.ToDateTime("01/25/2019")
                    },
                    new DbNews
                    {
                        Title = "EagleAirline liên tục mở rộng mạng bay quốc tế đến Nhật Bản với đường bay thứ 3 kết nối Hà Nội và Tokyo",
                        Author = "Xuân Hải",
                        Content = "(Hà Nội, Ngày 11/01/2019) – Trong không khí hân hoan mừng năm mới, hãng hàng không thế hệ mới Vietjet hôm nay chính thức khai thác đường bay kết nối thủ đô Hà Nội với Tokyo của Nhật Bản. Đây là đường bay thứ 3 giữa Việt Nam và Nhật Bản của hãng nhằm phục vụ nhu cầu đi lại tăng cao của người dân, thúc đẩy du lịch, giao thương và trao đổi văn hóa giữa hai nước." + "</br>" + "Lễ khai trương đường bay diễn ra tưng bừng tại tại sân bay Quốc tế Narita với sự tham dự của ông Vũ Hồng Nam, Đại sứ Việt Nam tại Nhật Bản, ông Yasuo Ishii, đại diện Bộ Đất đai, Hạ tầng, Vận tải và Du lịch Nhật Bản và ông Makoto Natsume, Chủ tịch kiêm Giám đốc Sân bay Quốc tế Narita.",
                        Date = Convert.ToDateTime("1/21/2019")
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
