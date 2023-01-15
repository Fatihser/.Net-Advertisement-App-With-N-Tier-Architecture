using FluentValidation;
using FSE.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.ValidationRules
{
    public class GenderCreateDtoValidator:AbstractValidator<GenderCreateDto>
    {
        public GenderCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
