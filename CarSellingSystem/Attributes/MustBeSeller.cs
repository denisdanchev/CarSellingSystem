using CarSellingSystem.Core.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using CarSellingSystem.Extensions;
using CarSellingSystem.Controllers;

namespace CarSellingSystem.Attributes
{
    public class MustBeSeller : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            ISellerService? sellerService = context.HttpContext.RequestServices.GetService<ISellerService>();

            if (sellerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (sellerService != null && sellerService.ExistByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(SellerController.Become), "Agent", null);
            }
        }
    }
}