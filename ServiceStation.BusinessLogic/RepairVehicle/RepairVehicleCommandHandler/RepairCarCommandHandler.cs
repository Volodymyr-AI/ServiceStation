using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.Domain;

namespace ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCommandHandler
{
    public class RepairCarCommandHandler : IRequestHandler<RepairVehicleCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public RepairCarCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RepairVehicleCommand request, CancellationToken cancellationToken)
        {
            var car =
                await _context.Cars.FirstOrDefaultAsync(car => car.Id == request.Id, cancellationToken);

            if (car != null)
            {
                car.Body = 100;
                car.Wheels = 100;
                car.Engine = 100;
                car.Breaks = 100;
                car.Undercarriage = 100;
                car.WheelBalancing = false;

                //count average of all integer fields
                var integerProperties = typeof(Car).GetProperties().Where(prop => prop.PropertyType == typeof(int)).ToList();

                var sum = 0;

                foreach (var prop in integerProperties)
                {
                    sum += (int)prop.GetValue(car);
                }

                var average = sum / (double)integerProperties.Count;

                car.State = average;

                await _context.SaveChangesAsync(cancellationToken);
            }

            return Unit.Value;
        }
    }
}
