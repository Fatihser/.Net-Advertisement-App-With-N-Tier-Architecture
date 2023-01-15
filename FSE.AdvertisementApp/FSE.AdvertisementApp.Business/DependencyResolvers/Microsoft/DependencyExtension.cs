using AutoMapper;
using FluentValidation;
using FSE.AdvertisementApp.Business.DependencyResolvers.ValidationRules;
using FSE.AdvertisementApp.Business.Interfaces;
using FSE.AdvertisementApp.Business.Mapping.AutoMapper;
using FSE.AdvertisementApp.Business.Services;
using FSE.AdvertisementApp.Business.ValidationRules;
using FSE.AdvertisementApp.DataAccess.Context;
using FSE.AdvertisementApp.DataAccess.UnitOfWork;
using FSE.AdvertisementApp.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FSE.AdvertisementApp.Business.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AdvertisementContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            

            services.AddScoped<IUow, Uow>();

            services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            services.AddTransient<IValidator<AdvertisementUpdateDto>,AdvertisementUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            services.AddTransient<IValidator<AppUserUpdateDto>,AppUserUpdateDtoValidator>();
            services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>,AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AdvertisementAppUserCreateDto>, AdvertisementAppUserCreateDtoValidator>();

            services.AddScoped<IProvidedServiceService,ProvidedServiceService>();
            services.AddScoped<IAdvertisementService, AdvertisementService>();
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();
        }
    }
}
