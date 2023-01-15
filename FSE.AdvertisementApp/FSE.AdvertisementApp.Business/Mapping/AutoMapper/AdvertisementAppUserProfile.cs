using AutoMapper;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.Mapping.AutoMapper
{
    public class AdvertisementAppUserProfile:Profile
    {
        public AdvertisementAppUserProfile()
        {
            CreateMap<AdvertisementAppUser, AdvertisementAppUserCreateDto>().ReverseMap();
            CreateMap<AdvertisementAppUser, AdvertisementAppUserListDto>().ReverseMap();
        }
    }
}
