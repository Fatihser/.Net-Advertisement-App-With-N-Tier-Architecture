using FSE.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Dtos
{
    public class GenderListDto:IDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
