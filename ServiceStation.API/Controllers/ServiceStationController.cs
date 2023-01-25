using Microsoft.AspNetCore.Mvc;

namespace ServiceStation.API.Controllers
{
    public class ServiceStationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
