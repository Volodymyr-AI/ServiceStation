using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommandHandler
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Guid>
    {
        protected IAppDbContext _dbContext;

        public UpdateCarCommandHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var entity =
                   await _dbContext.Cars.FirstOrDefaultAsync(car =>
                   car.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            entity.Engine = request.Engine;
            entity.Wheels = request.Wheels;
            entity.Breaks = request.Breaks;
            entity.Undercarriage = request.Undercarriage;
            entity.Body = request.Body;
            //optional only for car
            entity.WheelBalancing = request.WheelBalancing;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
