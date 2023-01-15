using FSE.AdvertisementApp.Dtos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Dtos
{
    public class AppUserLoginDto:IDto
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
