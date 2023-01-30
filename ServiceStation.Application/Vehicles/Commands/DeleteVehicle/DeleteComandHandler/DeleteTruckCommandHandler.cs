using MediatR;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.DeleteVehicle.DeleteComand;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.DeleteVehicle.DeleteComandHandler
{
    public class DeleteTruckCommandHandler
        : IRequestHandler<DeleteVehicleCommand>
    {
        private readonly IStationDbContext _dbContext;

        public DeleteTruckCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var truck = await _dbContext.Trucks.FindAsync(new object[] { request.VehicleId }, cancellationToken);

            if (truck == null || truck.VehicleId != request.VehicleId)
            {
                throw new NotFoundException(nameof(TruckDTO), request.VehicleId);
            }

            _dbContext.Trucks.Remove(truck);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
