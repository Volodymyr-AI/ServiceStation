using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCoommand;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCommandHandler
{
    public class RepairTruckCommandHandler : IRequestHandler<RepairVehicleCommand, string>
    {
        private readonly IAppDbContext _context;

        public RepairTruckCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(RepairVehicleCommand request, CancellationToken cancellationToken)
        {
            var truck =
                await _context.Trucks.FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

            var properties = truck.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(int));

            foreach (var property in properties)
            {
                property.SetValue(truck, 100);
            }

            truck.State = 100.0;

            await _context.Trucks.AddAsync(truck);
            await _context.SaveChangesAsync(cancellationToken);
            return "Truck is repaired";
        }
    }
}
