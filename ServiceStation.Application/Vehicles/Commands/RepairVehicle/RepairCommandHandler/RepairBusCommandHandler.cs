using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommand;

namespace ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommandHandler
{
    public class RepairBusCommandHandler : IRequestHandler<RepairBusCommand, Unit>
    {
        private readonly IAppDbContext _context;


        public RepairBusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RepairBusCommand request, CancellationToken cancellationToken)
        {
            var bus = await _context.Buses.FirstOrDefaultAsync(bus => bus.Id == request.Id, cancellationToken);

            if (bus != null)
            {
                var properties = bus.GetType().GetProperties().Where(p => p.PropertyType == typeof(int));

                foreach (var property in properties)
                {
                    property.SetValue(bus, 100);
                }

                bus.State = 100.0;//fully repaired
                bus.ChangeSeats = false;
            }
            else if (bus == null)
            {
                throw new NotFoundException(nameof(bus), request.Id);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
