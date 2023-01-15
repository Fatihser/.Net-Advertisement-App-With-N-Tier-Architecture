using AutoMapper;
using FluentValidation;
using FSE.AdvertisementApp.Business.Interfaces;
using FSE.AdvertisementApp.Business.Services;
using FSE.AdvertisementApp.DataAccess.UnitOfWork;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.ValidationRules
{
    public class ProvidedServiceService : 
        Service<ProvidedServiceCreateDto,ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService> 
        ,IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper,IValidator<ProvidedServiceCreateDto> createDtoValidator,
            IValidator<ProvidedServiceUpdateDto> updateDtoValidator,IUow uow):base(mapper,
                createDtoValidator,updateDtoValidator,uow)
        {

        }
    }
}
