using AutoMapper;
using FluentValidation;
using FSE.AdvertisementApp.Business.DependencyResolvers.Microsoft;
using FSE.AdvertisementApp.Business.Helpers;
using FSE.AdvertisementApp.UI.Mappings.AutoMapper;
using FSE.AdvertisementApp.UI.Models;
using FSE.AdvertisementApp.UI.ValidationRules;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration);
            services.AddTransient<IValidator<UserCreateModel>, UserCreateModelValidator>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt=> {
                    opt.Cookie.Name = "FseCookie";
                    opt.Cookie.HttpOnly = true;
                    opt.Cookie.SameSite = SameSiteMode.Strict;
                    opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                    opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                    opt.LoginPath = new PathString("/Account/SignIn");
                    opt.LogoutPath = new PathString("/Account/LogOut");
                    opt.AccessDeniedPath = new PathString("/Account/AccesDenied");
                });

            services.AddControllersWithViews();

            var profiles = ProfileHelper.GetProfiles();

            profiles.Add(new UserCreateModelProfile());

            var configuration = new MapperConfiguration(opt =>{
                opt.AddProfiles(profiles);
            });

            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
