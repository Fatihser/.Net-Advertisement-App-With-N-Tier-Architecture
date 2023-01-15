using FluentValidation;
using FSE.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementUpdateDtoValidator:AbstractValidator<AdvertisementUpdateDto>
    {
        public AdvertisementUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
