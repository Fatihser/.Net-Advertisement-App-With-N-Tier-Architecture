using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Entities
{
    public class Gender : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
