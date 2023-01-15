using FSE.AdvertisementApp.Common;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementService:IService<AdvertisementCreateDto,AdvertisementUpdateDto
        ,AdvertisementListDto,Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
