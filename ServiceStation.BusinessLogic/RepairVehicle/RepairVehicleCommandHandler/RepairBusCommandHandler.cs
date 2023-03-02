using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCoommand;
using ServiceStation.Domain;
using System.ComponentModel.Design;

namespace ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCommandHandler
{
    public class RepairBusCommandHandler : IRequestHandler<RepairTruckCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public RepairBusCommandHandler(IAppDbContext context) => _context = context;

        public async Task<Unit> Handle(RepairTruckCommand request, CancellationToken cancellationToken)
        {
            var bus =  await _context.Buses.FirstOrDefaultAsync(bus => bus.Id == request.Id, cancellationToken);

            
            if(bus != null)
            {
                var integerProperties = typeof(Bus).GetProperties().Where(prop => prop.PropertyType == typeof(int));

                foreach(var property in integerProperties)
                {
                    property.SetValue(bus, 100);
                }

                bus.State = 100.0;

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(Bus), request.Id);
            }


            return Unit.Value;
        }

    }
}
