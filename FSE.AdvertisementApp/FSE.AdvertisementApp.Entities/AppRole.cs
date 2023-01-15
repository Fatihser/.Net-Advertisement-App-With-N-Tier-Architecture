using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Entities
{
    public class AppRole:BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
