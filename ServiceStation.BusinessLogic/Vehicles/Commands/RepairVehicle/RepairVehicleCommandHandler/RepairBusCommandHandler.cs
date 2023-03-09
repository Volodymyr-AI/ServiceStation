using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCoommand;
using ServiceStation.Domain;
using System.ComponentModel.Design;

namespace ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCommandHandler
{
    public class RepairBusCommandHandler : IRequestHandler<RepairVehicleCommand, string>
    {
        private readonly IAppDbContext _context;

        public RepairBusCommandHandler(IAppDbContext context) => _context = context;

        public async Task<string> Handle(RepairVehicleCommand request, CancellationToken cancellationToken)
        {
            var bus = await _context.Buses.FirstOrDefaultAsync(bus => bus.Id == request.Id, cancellationToken);

            var properties = bus.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(int));

            foreach (var property in properties)
            {
                property.SetValue(bus, 100);
            }

            bus.State = 100.0;
            bus.ChangeSeats = false;

            await _context.Buses.AddAsync(bus);
            await _context.SaveChangesAsync(cancellationToken);
            return "Bus is repaired";
        }

    }
}
