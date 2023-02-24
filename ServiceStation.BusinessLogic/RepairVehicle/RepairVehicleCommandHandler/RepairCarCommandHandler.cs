using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.Domain;

namespace ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCommandHandler
{
    public class RepairCarCommandHandler : IRequestHandler<RepairVehicleCommand, Guid>
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

                var average = (car.Body + car.Wheels + car.Engine + car.Breaks + car.Undercarriage) / 5.0;
                car.State = average;

                await _context.SaveChangesAsync(cancellationToken);
            }

            return Guid.NewGuid();
        }
    }
}
