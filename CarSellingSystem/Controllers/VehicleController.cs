using CarSellingSystem.Attributes;
using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Core.Models.Vehicle;
using CarSellingSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace CarSellingSystem.Controllers
{
    public class VehicleController : BaseController
    {
        private readonly IVehicleService vehicleService;
        private readonly ISellerService sellerService;
        public VehicleController(IVehicleService _vehicleService, ISellerService _sellerService)
        {
            vehicleService = _vehicleService;
            sellerService = _sellerService;
        }

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
        [MustBeSeller]
        public async Task<IActionResult> Add()
        {
            var model = new VehicleFormModel()
            {
                Types = await vehicleService.AllTypesAsync()
            };

            return View(model);
        }

        [HttpPost]
        [MustBeSeller]
        public async Task<IActionResult> Add(VehicleFormModel model)
        {

            if (await vehicleService.TypesExistsAsync(model.TypeId) == false)
            {
                ModelState.AddModelError(nameof(model.TypeId), "");
            }

            if (ModelState.IsValid == false)
            {
                model.Types = await vehicleService.AllTypesAsync();

                return View(model);
            }

            int? sellerId = await sellerService.GetSellerIdAsync(User.Id());

            int newVehicleId = await vehicleService.CeateAsync(model,sellerId ?? 0);
            return RedirectToAction(nameof(Details), new { id = newVehicleId });
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
