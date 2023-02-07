using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceStation.API.Entities;
using ServiceStation.API.Exceptions;
using System.CodeDom;
using System.Data.Entity.Infrastructure;
using System.Net.WebSockets;

namespace ServiceStation.API.Controllers
{
    public class TruckController : Controller
    {
        private readonly ApplicationContext _context;

        public TruckController(ApplicationContext context)
        {
            _context = context;
        }
        [Route("/truck")]
        [HttpPost]
        public async Task<IActionResult> CreateTruck(Truck truck)
        {
            _context.Trucks.Add(
                new Truck
                {
                    VehicleId = Guid.NewGuid(),
                    Body = truck.Body,
                    Wheels = truck.Wheels,
                    Engine = truck.Engine,
                    Brakes = truck.Brakes,
                    Chassis = truck.Chassis,
                    AveragePoint = truck.AveragePoint,
                    Hydraulics = truck.Hydraulics
                });
            await _context.SaveChangesAsync();
            return Ok();
        }

        [Route("/truck/{id}")]
        [HttpPut]
        public async Task<IActionResult> GetById(Guid VehicleId, CancellationToken cancellationToken, Truck truck)
        {
            var entity =
                await _context.Trucks.FirstOrDefaultAsync(truck =>
                truck.VehicleId == VehicleId, cancellationToken);
            if (entity == null || entity.VehicleId != VehicleId)
            {
                throw new NotFoundException(nameof(Truck), VehicleId);
            }

            entity.Body = truck.Body;
            entity.Wheels = truck.Wheels;
            entity.Engine = truck.Engine;
            entity.Brakes = truck.Brakes;
            entity.Chassis = truck.Chassis;
            entity.AveragePoint = truck.AveragePoint;
            entity.Hydraulics = truck.Hydraulics;

            await _context.SaveChangesAsync(cancellationToken);

            return Ok();
        }

        [Route("/truck/estimate/{id}")]
        [HttpPost]
        public IActionResult Repair(Truck truck)
        {
            return Ok();
        }
    }
}
