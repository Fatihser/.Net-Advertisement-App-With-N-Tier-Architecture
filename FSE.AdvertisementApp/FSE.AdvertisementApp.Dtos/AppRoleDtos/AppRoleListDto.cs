using FSE.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Dtos
{
    public class AppRoleListDto:IDto
    {
        public int id { get; set; }
        public string Definition { get; set; }
    }
}
