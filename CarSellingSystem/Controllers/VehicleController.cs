using CarSellingSystem.Core.Models.Vehicle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSellingSystem.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllVehicleQueryModel();

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var model = new AllVehicleQueryModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = new VehicleDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(VehicleDetailsViewModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = new VehicleFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VehicleFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new VehicleDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, VehicleDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Buy(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
        public async Task<IActionResult> Sell(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
