using AutoMapper;
using FSE.AdvertisementApp.Business.Mapping.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.Helpers
{
    public class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
                new AppRoleProfile(),
                new AdvertisementProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile(),
            };
        }
    }
}
