using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Entities
{
    public class AdvertisementAppUserStatus:BaseEntity
    {
        public string Definition { get; set; }
        public List<AdvertisementAppUser> advertisementAppUsers { get; set; }
    }
}
