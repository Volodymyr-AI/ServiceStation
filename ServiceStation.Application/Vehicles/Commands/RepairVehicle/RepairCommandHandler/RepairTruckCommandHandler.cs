using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommandHandler
{
    public class RepairTruckCommandHandler : IRequestHandler<RepairTruckCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public RepairTruckCommandHandler(IAppDbContext context)
        {
           _context = context;
        }

        public async Task<Unit> Handle(RepairTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = 
                await _context.Trucks.FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

            if(truck != null)
            {
                var properties = truck.GetType().GetProperties().Where(p => p.PropertyType == typeof(int));
                foreach(var property in properties)
                {
                    property.SetValue(truck, 100);
                }

                truck.State = 100.0;
            }
            else if(truck == null)
            {
                throw new NotFoundException(nameof(truck), request.Id);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
