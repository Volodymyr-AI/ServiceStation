using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommand;
using ServiceStation.Domain.DTO;

namespace ServiceStation.API.Controllers
{
    public class ServiceStationController : Controller
    {
        private readonly IMapper _mapper;

        public ServiceStationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [Route("/car")]
        [HttpPost]
        public async IActionResult Index(CarDTO carDto, ) // create vehicle
        {
            var command = _mapper.Map<CreateCarCommand>(CarDTO);
            command.VehicleId = VehicleId;
            var vehicleId = await Mediator
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
