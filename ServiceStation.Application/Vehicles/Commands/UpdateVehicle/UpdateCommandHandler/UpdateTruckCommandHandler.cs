using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommandHandler
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand, Guid>
    {
        private IAppDbContext _appDbContext;

        public UpdateTruckCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _appDbContext.Trucks.FirstOrDefaultAsync(truck =>
                 truck.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new DirectoryNotFoundException();
            }

            entity.Engine = request.Engine;
            entity.Wheels = request.Wheels;
            entity.Breaks = request.Breaks;
            entity.Undercarriage = request.Undercarriage;
            entity.Body = request.Body;
            //optinal only for truck
            entity.Hydraulics = request.Hydraulics;

            return entity.Id;
        }
    }
}
