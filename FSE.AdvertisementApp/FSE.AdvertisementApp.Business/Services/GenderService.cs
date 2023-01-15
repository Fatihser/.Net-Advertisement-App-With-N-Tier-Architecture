using AutoMapper;
using FluentValidation;
using FSE.AdvertisementApp.Business.Interfaces;
using FSE.AdvertisementApp.DataAccess.UnitOfWork;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.Services
{
    public class GenderService:Service<GenderCreateDto,GenderUpdateDto,GenderListDto,
        Gender>,IGenderService
    {
        public GenderService(IMapper mapper,IValidator<GenderCreateDto> createValidator,
            IValidator<GenderUpdateDto> updateDtoValidator, IUow uow):base(mapper,
                createValidator,updateDtoValidator,uow)
        {

        }
    }
}
