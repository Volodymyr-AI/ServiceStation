using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommand;

namespace ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommandHandler
{
    public class RepairCarCommandHandler : IRequestHandler<RepairCarCommand, Unit>
    {
        private readonly IAppDbContext _context;


        public RepairCarCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RepairCarCommand request, CancellationToken cancellationToken)
        {
            var car =
                await _context.Cars.FirstOrDefaultAsync(car => car.Id == request.Id, cancellationToken);

            if(car != null)
            {
                var properties = car.GetType().GetProperties().Where(p => p.PropertyType == typeof(int));

                foreach(var property in properties)
                {
                    property.SetValue(car, 100);
                }
                car.State = 100.0;//fully repaired
                car.WheelBalancing = false;
            }
            else if(car == null)
            {
                throw new NotFoundException(nameof(car), request.Id);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
