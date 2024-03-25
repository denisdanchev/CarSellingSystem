using CarSellingSystem.Core.Contracts;
using CarSellingSystem.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarSellingSystem.Attributes
{
    public class NotASellerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            ISellerService? sellerService = context.HttpContext.RequestServices.GetService<ISellerService>();

            if (sellerService == null) 
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (sellerService != null && sellerService.ExistByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest); 
            }
        }
    }
}
