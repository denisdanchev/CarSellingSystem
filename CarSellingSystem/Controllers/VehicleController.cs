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
        public async Task<IActionResult> All([FromQuery]AllVehicleQueryModel query)
        {
            var model = await vehicleService.AllAsync(
                query.VehicleType,
                query.SearchTerm,
                query.Sorting,
                query.CurentPage,
                query.VehiclesPerPage);

            query.TotalVehiclesCount = model.TotalVehiclesCount;
            query.Vehicles = model.Vehicle;
            query.Types = await vehicleService.AllCategoriesNamesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {   
            var userId = User.Id();
            IEnumerable<VehicleServiceModel> model;

            if ( await sellerService.ExistByIdAsync(userId))
            {

                int sellerId = await sellerService.GetSellerIdAsync(userId) ?? 0;
                model = await vehicleService.AllVehiclesBySellerId(sellerId);
            }
            else
            {
                model = await vehicleService.AllVehiclesByUserId(int.Parse(userId));
            }    

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await vehicleService.VehicleDetailsByIdAsync(id);


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
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist");
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
            if (await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if (await vehicleService.HasSellerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }
            var model = await vehicleService.GetVehicleFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, VehicleFormModel model)
        {
            if (await vehicleService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }
            if (await vehicleService.HasSellerWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }
            if (await vehicleService.TypesExistsAsync(model.TypeId) == false)
            {
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Types = await vehicleService.AllTypesAsync();

                return View(model);
            }

            await vehicleService.EditAsync(id,model);

            return RedirectToAction(nameof(Details), new { id });

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
