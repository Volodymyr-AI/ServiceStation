using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.API.Models.CreateVehicleDtos;
using ServiceStation.API.Models.UpdateVehicleDtos;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommand;
using ServiceStation.Application.Vehicles.Queries.GetPriceForRepair.SetPrice;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQuery;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.Domain;
using ServiceStation.Persistense;

namespace ServiceStation.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ServiceStationController : BaseController
    {
        private readonly IMapper _mapper;
        public ServiceStationController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // Car commands and queries
        [HttpPost]
        [Route("/car")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateCar([FromBody] CreateCarDto createCarDto)
        {
            var command = _mapper.Map<CreateCarCommand>(createCarDto);
            var carId = await Mediator.Send(command);
            return Ok(carId);
        }


        [HttpGet("/car/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CarDetailsVm>> GetCarById(Guid id)
        {
            var query = new GetCarQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut]
        [Route("/car/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarDto updateCarDto)
        {
            var command = _mapper.Map<UpdateCarCommand>(updateCarDto);
            var result = await Mediator.Send(command);



            return Ok(result);
        }

        [HttpPost]
        [Route("/car/repair/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RepairCar(Guid id)
        {
            var command = new RepairCarCommand(id);
            await Mediator.Send(command);
            return Ok();
        }
        [HttpPost]
        [Route("/car/estimate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EstimateCar(Guid id)
        {
            var command = new SetCarPriceCommand(id);
            var price = await Mediator.Send(command);

            return Ok(price);
        }

        [HttpPost]
        [Route("/vehicle/bulk")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> BulkInsertVehicles([FromBody] List<CreateVehicleDto> createVehicleDtos)
        {
            var commands = new List<CreateVehicleCommand>();

            foreach (var createVehicleDto in createVehicleDtos)
            {
                CreateVehicleCommand command;
                switch (createVehicleDto.Type)
                {
                    case VehicleType.Car:
                        command = _mapper.Map<CreateCarCommand>(createVehicleDto);
                        break;
                    case VehicleType.Bus:
                        command = _mapper.Map<CreateBusCommand>(createVehicleDto);
                        break;
                    case VehicleType.Truck:
                        command = _mapper.Map<CreateTruckCommand>(createVehicleDto);
                        break;
                    default:
                        return BadRequest("Invalid vehicle type");
                }

                commands.Add(command);
            }

            var result = await Mediator.Send(new BulkInsertVehiclesCommand(commands));
            return Ok(result);
        }

        // Bus commands and queries
        [HttpPost("/bus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateBus([FromBody] CreateBusDto createBusDto)
        {
            var command = _mapper.Map<CreateBusCommand>(createBusDto);
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("/bus/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateBus([FromBody] UpdateBusDto updateBusDto)
        {
            var command = _mapper.Map<UpdateBusCommand>(updateBusDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("/bus/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BusDetailsVm>> GetBusById(Guid id)
        {
            var query = new GetBusQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Route("/bus/repair/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RepairBus(Guid id)
        {
            var command = new RepairBusCommand(id);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("/bus/estimate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EstimateBus(Guid id)
        {
            var command = new SetBusPriceCommand(id);
            var price = await Mediator.Send(command);

            return Ok(price);
        }

        //Truck commands and queries
        [HttpPost("/truck")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateTruck([FromBody] CreateTruckDto createTruckDto)
        {
            var command = _mapper.Map<CreateTruckCommand>(createTruckDto);
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("/truck/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTruck([FromBody] UpdateTruckDto updateTruckDto)
        {
            var command = _mapper.Map<UpdateTruckCommand>(updateTruckDto);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("/truck/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TruckDetailsVm>> GetTruckById(Guid id)
        {
            var query = new GetTruckQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Route("/truck/repair/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RepairTruck(Guid id)
        {
            var command = new RepairTruckCommand(id);
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("/truck/estimate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> EstimateTruck(Guid id)
        {
            var command = new SetTruckPriceCommand(id);
            var price = await Mediator.Send(command);

            return Ok(price);
        }
    }
}