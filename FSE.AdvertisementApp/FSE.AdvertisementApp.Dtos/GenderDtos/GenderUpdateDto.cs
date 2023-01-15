using FSE.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Dtos
{
    public class GenderUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
