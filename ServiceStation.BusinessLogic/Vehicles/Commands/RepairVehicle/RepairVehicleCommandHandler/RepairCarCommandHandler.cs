using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCoommand;

namespace ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCommandHandler
{
    public class RepairCarCommandHandler : IRequestHandler<RepairVehicleCommand, string>
    {
        private readonly IAppDbContext _context;

        public RepairCarCommandHandler(IMediator mediator, IAppDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(RepairVehicleCommand request, CancellationToken cancellationToken)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car =>
                car.Id == request.Id, cancellationToken);

            var properties = car.GetType().GetProperties()
                .Where(p => p.PropertyType == typeof(int));

            foreach (var property in properties)
            {
                property.SetValue(car, 100);
            }

            car.State = 100.0; // fully repaired
            car.WheelBalancing = false;

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync(cancellationToken);
            return "Car is repaired";
        }
    }
}
