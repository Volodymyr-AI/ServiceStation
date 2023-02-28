using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServiceStation.API.Models.CreateVehicleDtos;
using ServiceStation.API.Models.RepairVehicleDtos;
using ServiceStation.API.Models.SetPriceDto;
using ServiceStation.API.Models.UpdateVehicleDtos;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQuery;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCoommand;
using ServiceStation.BusinessLogic.SetPriceForRepair;

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
        public async Task<IActionResult> RepairCar([FromBody] RepairCarDto repairCarDto)
        {
            var command = _mappper.Map<RepairCarCommand>(repairCarDto);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost("/car/estimate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> SetPriceCar([FromBody] SetPriceCarDto setPriceCarDto)
        {
            var command = _mappper.Map<SetPriceVehicleCommand>(setPriceCarDto);
            var price = await _mediator.Send(command);

            return Ok(price);   
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
        [HttpPost("/bus/repair/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RepairBus([FromBody] RepairBusDto repairBusDto)
        {
            var command = _mappper.Map<RepairBusCommand>(repairBusDto);
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPost("/bus/estimate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> SetPriceBus([FromBody] SetPriceBusDto setPriceBusDto)
        {
            var command = _mappper.Map<SetPriceVehicleCommand>(setPriceBusDto);
            var price = await _mediator.Send(command);

            return Ok(price);
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
        [HttpPost("/truck/repair/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RepairTruck([FromBody] RepairTruckDto repairTruckDto)
        {
            var command = _mappper.Map<RepairTruckCommand>(repairTruckDto);
            await _mediator.Send(command);

            return NoContent();
        }
        [HttpPost("/truck/estimate/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> SetPriceTruck([FromBody] SetPriceTruckDto setPriceTruckDto)
        {
            var command = _mappper.Map<SetPriceVehicleCommand>(setPriceTruckDto);
            var price = await _mediator.Send(command);

            return Ok(price);
        }
    }
}
