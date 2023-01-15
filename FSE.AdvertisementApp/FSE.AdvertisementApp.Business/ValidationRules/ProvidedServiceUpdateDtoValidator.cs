using FluentValidation;
using FSE.AdvertisementApp.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.DependencyResolvers.ValidationRules
{
    public class ProvidedServiceUpdateDtoValidator:AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x=>x.Id).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
