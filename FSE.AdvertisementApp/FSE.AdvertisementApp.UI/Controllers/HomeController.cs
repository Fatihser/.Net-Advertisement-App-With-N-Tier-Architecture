using FSE.AdvertisementApp.Business.Interfaces;
using FSE.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FSE.AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedServideService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedServideService, IAdvertisementService advertisementService)
        {
            _providedServideService = providedServideService;
            _advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _providedServideService.GetAllAsync();
            return this.ResponseView(response);
        }
        public async Task<IActionResult> HumanResource()
        {
            var response = await _advertisementService.GetActivesAsync();
            return this.ResponseView(response);
        }
    }
}
