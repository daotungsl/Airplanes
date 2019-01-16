using System.ComponentModel.DataAnnotations;

namespace Airplanes.Models
{
    /// <summary>
    /// Thông tin chi tiết về 1 thành phố có hoặc không có sân bay
    /// </summary>
    public class DbCity
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public long ZipCode { get; set; }

        // Thành phố trực thuộc quốc gia nào
        public long DbCountryId { get; set; }

        public DbCountry DbCountry { get; set; }

        // Thành phố sở hữu sân bay nào
        public DbAirPort DbAirPort { get; set; }

        public AirportStatus AirportStatus { get; set; }
    }

    public enum AirportStatus
    {
        Exist = 1,
        NotExist = 0
    }
}