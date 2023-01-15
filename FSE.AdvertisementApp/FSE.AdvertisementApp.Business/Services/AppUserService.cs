using AutoMapper;
using FluentValidation;
using FSE.AdvertisementApp.Business.Extensions;
using FSE.AdvertisementApp.Business.Interfaces;
using FSE.AdvertisementApp.Common;
using FSE.AdvertisementApp.DataAccess.UnitOfWork;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.Business.Services
{
    public class AppUserService:Service<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,
        AppUser>,IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createValidator;
        private readonly IValidator<AppUserLoginDto> _loginDtoValidator;
        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator,
            IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserLoginDto> loginDtoValidator) : base(mapper,
                createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createValidator = createDtoValidator;
            _loginDtoValidator = loginDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto,int roleId)
        {
            var validatonResult = _createValidator.Validate(dto);
            if (validatonResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);

                //1.yol

                user.AppUserRoles = new List<AppUserRole>();
                user.AppUserRoles.Add(new AppUserRole
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _uow.GetRepository<AppUser>().CreateAsync(user);

                //2.yol

                //await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                //{
                //    AppUser=user,
                //    AppRoleId=roleId
                //});

                await _uow.SaveChangesAsync();

                return new Response<AppUserCreateDto>(ResponseType.Success, dto);

                //await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole 
                //{ 
                //    AppRoleId=roleId,
                //    AppUserId
                //});
            }
            return new Response<AppUserCreateDto>(dto, validatonResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
        {
            var validationResult = _loginDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user=await _uow.GetRepository<AppUser>().GetByFilterAsync(x=> 
                x.Username==dto.Username && x.Password==dto.Password);
                if (user!=null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(user);
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound,
                    "Kullanici adi veya sifre hatali");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError,
                "Kullanici adi veya sifre bos olamaz");
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles=await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(
                x => x.AppUserId == userId));
            if (roles==null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound,"Ilgili rol bulunamadi.");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }

    }
}
