using AdvertisementApp.Bussniess.Interfaces;
using AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService providedServiceService;
        private readonly IAdvertisementService advertisementService;
        public HomeController(IProvidedServiceService providedServiceService, IAdvertisementService advertisementService)
        {
            this.providedServiceService = providedServiceService;
            this.advertisementService = advertisementService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await providedServiceService.GetAllAsync();
            return this.ResponseView(response);
        }

        public async Task<IActionResult> HumanResource()
        {
            var response = await advertisementService.GetAllAsync();
            return this.ResponseView(response);
        }
    }
}
