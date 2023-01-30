using MediatR;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.DeleteVehicle.DeleteComand;
using ServiceStation.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.DeleteVehicle.DeleteComandHandler
{
    public class DeleteBusCommandHandler
        : IRequestHandler<DeleteVehicleCommand>
    {
        private readonly IStationDbContext _dbContext;

        public DeleteBusCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var bus = await _dbContext.Buses.FindAsync(new object[] { request.VehicleId }, cancellationToken);

            if (bus == null || bus.VehicleId != request.VehicleId)
            {
                throw new NotFoundException(nameof(BusDTO), request.VehicleId);
            }

            _dbContext.Buses.Remove(bus);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
