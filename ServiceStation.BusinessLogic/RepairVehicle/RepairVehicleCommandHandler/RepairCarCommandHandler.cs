using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCoommand;
using ServiceStation.Domain;

namespace ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCommandHandler
{
    public class RepairCarCommandHandler : IRequestHandler<RepairTruckCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public RepairCarCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RepairTruckCommand request, CancellationToken cancellationToken)
        {
            var car =
                await _context.Cars.FirstOrDefaultAsync(car => car.Id == request.Id, cancellationToken);

            if (car != null)
            {
                var integerProperties = car.GetType()
                    .GetProperties()
                    .Where(p => p.PropertyType == typeof(int)).ToList();

                foreach(var property in integerProperties)
                {
                    property.SetValue(car, 100);
                }

                car.State = 100.0; // average state is 100%, car is fully repaired

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            return Unit.Value;
        }
    }
}
