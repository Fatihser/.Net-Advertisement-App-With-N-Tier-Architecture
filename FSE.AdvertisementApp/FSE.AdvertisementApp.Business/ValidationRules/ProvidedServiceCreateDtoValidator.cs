using FluentValidation;
using FSE.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.DependencyResolvers.ValidationRules
{
    public class ProvidedServiceCreateDtoValidator:AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceCreateDtoValidator()
        {
            RuleFor(x=>x.Description).NotEmpty();
            RuleFor(x=>x.ImagePath).NotEmpty();
            RuleFor(x=>x.Description).NotEmpty();
        }
    }
}
