using FSE.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Dtos
{
    public class MilitaryStatusListDto:IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
