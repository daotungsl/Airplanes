using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineTicketResourceServer.Models
{
    /// <summary>
    /// Thông tin của hành khách được điền trên vé
    /// </summary>
    public class DbPassenger
    {
        [Key]
        public long Id { get; set; }
        public long UId { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }

        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }

        // Lien Ket 1 vé bay tương ứng với 1 khách hàng trong 1 chuyến bay
        public DbTicket DbTicket { get; set; }

        public DbPassenger()
        {
            CreatedAt = DateTime.Now.Ticks;
            UpdatedAt = 0;
        }
    }

    public enum Gender
    {
        Mr = 1,
        Miss = 0
    }
}
