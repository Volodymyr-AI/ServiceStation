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
    public class RepairBusCommandHandler : IRequestHandler<RepairBusCommand, Unit>
    {
        private readonly IAppDbContext _context;


        public RepairBusCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(RepairBusCommand request, CancellationToken cancellationToken)
        {

            {
                var properties = bus.GetType().GetProperties().Where(p => p.PropertyType == typeof(int));

                {
                    property.SetValue(bus, 100);
                }

                bus.ChangeSeats = false;
            }
            {
                throw new NotFoundException(nameof(bus), request.Id);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
