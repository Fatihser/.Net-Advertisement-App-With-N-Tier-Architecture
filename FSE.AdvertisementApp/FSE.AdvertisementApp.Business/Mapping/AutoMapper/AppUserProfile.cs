using AutoMapper;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.Mapping.AutoMapper
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<AppUser, AppUserCreateDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
        }
    }
}
