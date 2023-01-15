using FSE.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Dtos
{
    public class AdvertisementCreateDto:IDto
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
