using AutoMapper;
using FluentValidation;
using FSE.AdvertisementApp.Business.Extensions;
using FSE.AdvertisementApp.Business.Interfaces;
using FSE.AdvertisementApp.Common;
using FSE.AdvertisementApp.Common.Enums;
using FSE.AdvertisementApp.DataAccess.UnitOfWork;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService: IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;
        private readonly IMapper _mapper;

        public AdvertisementAppUserService(IUow uow, IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper)
        {
            _uow = uow;
            _createDtoValidator = createDtoValidator;
            _mapper = mapper;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(
                    x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);

                if (control==null)
                {
                var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                await _uow.SaveChangesAsync();
                return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }
                List<CustomValidationError> errors = new List<CustomValidationError>
                {
                    new CustomValidationError
                    {
                        ErrorMessage="Daha once basvurulan ilana basvurulamaz.",
                        PropertyName=""
                    }
                };

                return new Response<AdvertisementAppUserCreateDto>(dto, errors);
            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var list=await query.Include(x => x.Advertisement).Include(x => x.AdvertisementAppUserStatus)
                .Include(x => x.MilitaryStatus).Include(x => x.AppUser).ThenInclude(x=>x.Gender)
                .Where(x => x.AdvertisementAppUserStatusId 
                == (int)type).ToListAsync();

            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }

        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            //var unchanged =await _uow.GetRepository<AdvertisementAppUser>().FindAsync(advertisementAppUserId);
            //var changed = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.Id ==
            //  advertisementAppUserId);
            //changed.AdvertisementAppUserStatusId = (int)type;
            //_uow.GetRepository<AdvertisementAppUser>().Update(changed, unchanged);

            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var entity = await query.SingleOrDefaultAsync(x => x.Id == advertisementAppUserId);
            entity.AdvertisementAppUserStatusId = (int)type;
            await _uow.SaveChangesAsync();
        }

    }
}
