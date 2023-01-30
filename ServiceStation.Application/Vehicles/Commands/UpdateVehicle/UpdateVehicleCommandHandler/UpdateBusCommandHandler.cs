using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommand;
using ServiceStation.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateVehicleCommandHandler
{
    public class UpdateBusCommandHandler
        : IRequestHandler<UpdateBusCommand>
    {
        private readonly IStationDbContext _dbContext;

        private UpdateBusCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateBusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Buses.FirstOrDefaultAsync(bus =>
                            bus.VehicleId == request.VehicleId, cancellationToken);

            if (entity == null || entity.VehicleId != request.VehicleId)
            {
                throw new NotFoundException(nameof(CarDTO), request.VehicleId);
            }

            entity.Body = request.Body;
            entity.Wheels = request.Wheels;
            entity.Engine = request.Engine;
            entity.Brakes = request.Brakes;
            entity.Chassis = request.Chassis;
            entity.Interior= request.Interior;
            entity.Handrails= request.Handrails;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
