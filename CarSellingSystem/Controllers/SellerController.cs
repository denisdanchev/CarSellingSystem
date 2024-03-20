﻿using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Core.Models.Seller;
using CarSellingSystem.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Become()
        {
            if (await sellerService.ExistByIdAsync(User.Id()))
            {
                return BadRequest();
            }

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
