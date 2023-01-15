using FluentValidation;
using FSE.AdvertisementApp.Common.Enums;
using FSE.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator:AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            this.RuleFor(x => x.AdvertisementAppUserStatusId).NotEmpty();
            this.RuleFor(x => x.AdvertisementId).NotEmpty();
            this.RuleFor(x => x.AppUserId).NotEmpty();
            this.RuleFor(x => x.CvPath).NotEmpty().WithMessage("Bir cv dosyasi seciniz.");
            this.RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId ==
              (int)MilitaryStatusType.Tecilli).WithMessage("Tecil tarihi bos birakilamaz.");
        }   
    }
}
