using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.Interfaces
{
    public interface IProvidedServiceService : IService<ProvidedServiceCreateDto,
        ProvidedServiceUpdateDto,ProvidedServiceListDto,ProvidedService>
    {

    }
}
