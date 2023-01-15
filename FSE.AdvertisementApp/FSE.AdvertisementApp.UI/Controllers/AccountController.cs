using AutoMapper;
using FluentValidation;
using FSE.AdvertisementApp.Business.Interfaces;
using FSE.AdvertisementApp.Common.Enums;
using FSE.AdvertisementApp.Dtos;
using FSE.AdvertisementApp.UI.Extensions;
using FSE.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateModel> _UserCreateModelValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;

        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService, IMapper mappers)
        {
            _genderService = genderService;
            _UserCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
            _mapper = mappers;
        }

        public async Task<IActionResult> SignUp()
        {
            var response=await _genderService.GetAllAsync();

            var model = new UserCreateModel
            {
                Genders = new SelectList(response.Data,"Id","Definition")
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel model)
        {
            var result = _UserCreateModelValidator.Validate(model);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(model);
                var createResponse = await _appUserService.CreateWithRoleAsync(dto,(int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            model.Genders = new SelectList(response.Data, "Id", "Definition",model.GenderId);
            return View(model);
        }

        public IActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto dto)
        {
            var result=await _appUserService.CheckUserAsync(dto);
            if (result.ResponseType==Common.ResponseType.Success)
            {
                //ilgili kullanicinin rollerinin cekilmeli.
                var roleResult= await _appUserService.GetRolesByUserIdAsync(result.Data.Id);
                var claims = new List<Claim>();

                if (roleResult.ResponseType==Common.ResponseType.Success)
                {
                    foreach (var role in roleResult.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role,role.Definition));
                    }
                }

                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdenty = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = dto.RememberMe,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdenty),
                    authProperties);

                return RedirectToAction("Index", "Home");
            }


            ModelState.AddModelError("Kullanici adi veya sifre hatali.", result.Message);
            return View(dto);
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
