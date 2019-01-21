using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Airplanes.Models.Custom
{
    public class AirplanesUser : IdentityUser
    {
        [PersonalData]
        public long UId { get; set; }

        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public UserGender Gender { get; set; }

        [PersonalData]
        public DateTime Birthday { get; set; }

        [PersonalData]
        public string IdNumber { get; set; }

        [PersonalData]
        public string Address { get; set; }

        // Điểm tích lũy khi mua vé hoặc hủy vé sẽ thay đổi
        [PersonalData]
        public int RewardPoints { get; set; }

        [PersonalData]
        public DateTime CreatedAt { get; set; }

        [PersonalData]
        public DateTime UpdatedAt { get; set; }

        public ICollection<DbRewardPointsLog> DbRewardPointsLogs { get; set; }

        public ICollection<DbOrder> DbOrders { get; set; }

        public ICollection<DbPassenger> DbPassengers { get; set; }
    }

    public enum UserGender
    {
        Female = 0,
        Male = 1,
        Other = 2
    }
}
