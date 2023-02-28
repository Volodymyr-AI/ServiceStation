using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCoommand;
using ServiceStation.Domain;

namespace ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCommandHandler
{
    public class RepairBusCommandHandler : IRequestHandler<RepairTruckCommand, Unit>
    {
        private readonly IAppDbContext _context;

        public RepairBusCommandHandler(IAppDbContext context) => _context = context;

        public async Task<Unit> Handle(RepairTruckCommand request, CancellationToken cancellationToken)
        {
            var bus =  await _context.Buses.FirstOrDefaultAsync(bus => bus.Id == request.Id, cancellationToken);

            if(bus == null)
            {
                throw new NotFoundException(nameof(Bus), request.Id);
            }
            else
            {
                bus.Body = 100;
                bus.Wheels = 100;
                bus.Engine = 100;
                bus.Breaks = 100;
                bus.Undercarriage = 100;
                bus.InteriorAndHandrails = 100;
                bus.ChangeSeats = false;

                var integerProperties = typeof(Bus).GetProperties().Where(prop => prop.PropertyType == typeof(int)).ToList();

                var sum = 0;

                foreach(var prop in integerProperties)
                {
                    sum += (int)prop.GetValue(bus);
                }

                var average = sum / (double)integerProperties.Count;

                bus.State = average;

                await _context.SaveChangesAsync(cancellationToken);
            }


            return Unit.Value;
        }

    }
}
