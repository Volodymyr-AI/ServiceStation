using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.API.Models.CreateVehicleDtos;
using ServiceStation.API.Models.RepairVehicleDto;
using ServiceStation.API.Models.UpdateVehicleDtos;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQuery;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.BusinessLogic.RepairVehicle;

namespace ServiceStation.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ServiceStationController : ControllerBase
    {
        private IMapper _mappper;
        IMediator _mediator;

        public ServiceStationController(IMapper mappper, IMediator mediator)
        {
            _mappper = mappper;
            _mediator = mediator;
        } 
        // Car commands and queries
        [HttpPost("/car")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateCar([FromBody] CreateCarDto createCarDto)
        {
            var command = _mappper.Map<CreateCarCommand>(createCarDto);
            var id = await _mediator.Send(command);
            
            return Ok(id);
        }

        [HttpPut("/car/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCar([FromBody] UpdateCarDto updateCarDto)
        {
            var command = _mappper.Map<UpdateCarCommand>(updateCarDto);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("/car/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CarDetailsVm>> GetCarById(Guid id)
        {
            var query = new GetCarQuery
            {
                Id = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("/car/repair/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RepairCar([FromBody] UpdateCarDto updateCarDto)
        {
            var command = _mappper.Map<RepairVehicleCommand>(updateCarDto);
            await _mediator.Send(command);

            return NoContent();
        }
        // Bus commands and queries
        [HttpPost("/bus")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateBus([FromBody] CreateBusDto createBusDto)
        {
            var command = _mappper.Map<CreateBusCommand>(createBusDto);
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("/bus/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateBus([FromBody] UpdateBusDto updateBusDto)
        {
            var command = _mappper.Map<UpdateBusCommand>(updateBusDto);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("/bus/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BusDetailsVm>> GetBusById(Guid id)
        {
            var query = new GetBusQuery
            {
                Id = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
        //Truck commands and queries
        [HttpPost("/truck")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateTruck([FromBody] CreateTruckDto createTruckDto)
        {
            var command = _mappper.Map<CreateTruckCommand>(createTruckDto);
            var id = await _mediator.Send(command);

            return Ok(id);
        }

        [HttpPut("/truck/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateTruck([FromBody] UpdateTruckDto updateTruckDto)
        {
            var command = _mappper.Map<UpdateTruckCommand>(updateTruckDto);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("/truck/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TruckDetailsVm>> GetTruckById(Guid id)
        {
            var query = new GetTruckQuery
            {
                Id = id
            };
            var vm = await _mediator.Send(query);
            return Ok(vm);
        }
    }
}
