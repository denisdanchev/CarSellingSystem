using CarSellingSystem.Attributes;
using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Core.Models.Seller;
using CarSellingSystem.Extensions;
using Microsoft.AspNetCore.Mvc;
using static CarSellingSystem.Core.Constants.MessageConstants;

namespace CarSellingSystem.Controllers
{
    public class SellerController : BaseController
    {
        private readonly ISellerService sellerService;

        public SellerController(ISellerService _sellerService)
        {
            sellerService = _sellerService;
        }

        [HttpGet]
        [NotASeller]
        public IActionResult Become()
        {
            var model = new BecomeSellerFormModel();

            return View(model);
        }

        [HttpPost]
        [NotASeller]
        public async Task<IActionResult> Become(BecomeSellerFormModel model)
        {
            if (await sellerService.UserWithPhoneNumberExistsAsync(model.PhoneNumber)) 
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), PhoneExists);
            }
            if (await sellerService.UserHasSellsAsync(User.Id()))
            {
                ModelState.AddModelError("Error", HasSells);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await sellerService.CreateAsync(User.Id(), model.PhoneNumber);
            return RedirectToAction(nameof(VehicleController.All), "Vehicle");
        }
            
    }
}
