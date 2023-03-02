using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCoommand;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCommandHandler
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

            if (truck != null)
            {
                //count average of all integer fields
                var integerProperties = typeof(Truck).GetProperties().Where(prop => prop.PropertyType == typeof(int));

                foreach(var property in integerProperties)
                {
                    property.SetValue(truck, 100);
                }

                //var sum = 0;
                //
                //foreach (var prop in integerProperties)
                //{
                //    sum += (int)prop.GetValue(truck);
                //}
                //
                //var average = sum / (double)integerProperties.Count;

                truck.State = 100.0;

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException(nameof(Truck), request.Id);
            }

            return Unit.Value;
        }
    }
}
