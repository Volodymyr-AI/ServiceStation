using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateVehicleCommandHandler
{
    public class UpdateTruckCommandHandler
        : IRequestHandler<UpdateTruckCommand>
    {
        private readonly IStationDbContext _dbContext;

        private UpdateTruckCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Trucks.FirstOrDefaultAsync(truck =>
                            truck.VehicleId == request.VehicleId, cancellationToken);

            if (entity == null || entity.VehicleId != request.VehicleId)
            {
                throw new NotFoundException(nameof(Car), request.VehicleId);
            }

            entity.Body = request.Body;
            entity.Wheels = request.Wheels;
            entity.Engine = request.Engine;
            entity.Brakes = request.Brakes;
            entity.Chassis = request.Chassis;
            entity.Hydraulics= request.Hydraulics;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
