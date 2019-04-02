using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers
{
    public class HomeController : ControllerBase
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/index.html");
        }
    }
}
