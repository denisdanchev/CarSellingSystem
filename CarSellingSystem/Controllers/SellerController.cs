using CarSellingSystem.Core.Models.Seller;
using Microsoft.AspNetCore.Mvc;

namespace CarSellingSystem.Controllers
{
    public class SellerController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Become()
        {
            var model = new BecomeSellerFormModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Become(BecomeSellerFormModel model)
        {
            return RedirectToAction(nameof(VehicleController.All), "Vehicle");
        }
            
    }
}
