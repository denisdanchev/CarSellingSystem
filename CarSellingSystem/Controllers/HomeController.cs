using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Core.Models.Home;
using CarSellingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarSellingSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleService vehicleService;

        public HomeController(ILogger<HomeController> logger,
            IVehicleService _vehicleservice)
        {
            _logger = logger;
            vehicleService = _vehicleservice;
        }
       
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await vehicleService.LastThreeVehicle();

            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
