using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommand;
using ServiceStation.Domain.DTO;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateVehicleCommandHandler
{
    public class UpdateCarCommandHandler
        : IRequestHandler<UpdateCarCommand>
    {
        private readonly IStationDbContext _dbContext;

        private UpdateCarCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Cars.FirstOrDefaultAsync(car =>
                            car.VehicleId == request.VehicleId, cancellationToken);

            if(entity == null || entity.VehicleId != request.VehicleId)
            {
                throw new NotFoundException(nameof(CarDTO), request.VehicleId);
            }

            entity.Body = request.Body;
            entity.Wheels = request.Wheels;
            entity.Engine = request.Engine;
            entity.Brakes = request.Brakes;
            entity.Chassis = request.Chassis;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
