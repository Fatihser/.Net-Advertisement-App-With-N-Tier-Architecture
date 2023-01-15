using AutoMapper;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.Mapping.AutoMapper
{
    public class AppRoleProfile:Profile
    {
        public AppRoleProfile()
        {
            CreateMap<AppRole, AppRoleListDto>().ReverseMap();
        }
    }
}
