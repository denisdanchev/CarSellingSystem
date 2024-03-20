using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarSellingSystem.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       
    }
}
