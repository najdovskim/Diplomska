using Microsoft.AspNetCore.Mvc;

namespace Diplomska.API.Controllers
{
    public class DriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
