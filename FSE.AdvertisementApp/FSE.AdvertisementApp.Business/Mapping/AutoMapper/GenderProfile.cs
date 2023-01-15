using AutoMapper;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.Mapping.AutoMapper
{
    public class GenderProfile:Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderListDto>().ReverseMap();
            CreateMap<Gender, GenderCreateDto>().ReverseMap();
            CreateMap<Gender, GenderUpdateDto>().ReverseMap();
        }
    }
}
