using AutoMapper;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.UI.Mappings.AutoMapper
{
    public class UserCreateModelProfile:Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>();
        }
    }
}
