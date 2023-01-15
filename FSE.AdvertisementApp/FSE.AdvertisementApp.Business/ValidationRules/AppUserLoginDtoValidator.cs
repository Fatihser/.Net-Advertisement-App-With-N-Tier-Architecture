using FluentValidation;
using FSE.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.ValidationRules
{
    class AppUserLoginDtoValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanici adi bos olamaz.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola bos olamaz.");
        }
    }
}
