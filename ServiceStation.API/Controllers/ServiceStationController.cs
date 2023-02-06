using Microsoft.AspNetCore.Mvc;

namespace ServiceStation.API.Controllers
{
    public class ServiceStationController : Controller
    {
        [Route("/car")]
        [HttpPost]
        public async IActionResult CreateVehicle() // create vehicle
        {
            
        }
        [Route("/car/bulk")]
        [HttpPost]
        public IActionResult AddVehicles() // fast add vehicles
        {
            return View();
        }

        [Route("/car/{id}")]
        [HttpPut]
        public IActionResult UpdateVehicles() // update vehicle
        {
            return View();
        }

        [Route("/car/{id}")]
        [HttpGet]
        public IActionResult GetVehicles() // get the vehicle via id
        {
            return View();
        }
    }
}
