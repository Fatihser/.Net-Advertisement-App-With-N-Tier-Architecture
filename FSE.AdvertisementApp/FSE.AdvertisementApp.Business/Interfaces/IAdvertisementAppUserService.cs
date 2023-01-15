using FSE.AdvertisementApp.Common;
using FSE.AdvertisementApp.Common.Enums;
using FSE.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
        Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);
    }
}
