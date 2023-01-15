using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Entities
{
    public class AppUserRole:BaseEntity
    {
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int AppRoleId { get; set; }
        public AppRole AppRole { get; set; }
    }
}
