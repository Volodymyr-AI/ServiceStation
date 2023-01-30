using MediatR;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.DeleteVehicle.DeleteComand;
using ServiceStation.Domain.DTO;
using System.Xml;

namespace ServiceStation.Application.Vehicles.Commands.DeleteVehicle.DeleteComandHandler
{
    public class DeleteCarCommandHandler
        : IRequestHandler<DeleteVehicleCommand>
    {
        private readonly IStationDbContext _dbContext;

        public DeleteCarCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteVehicleCommand request,
            CancellationToken cancellationToken)
        {
            var car = await _dbContext.Cars.FindAsync(new object[] { request.VehicleId }, cancellationToken);
           
            if(car == null || car.VehicleId != request.VehicleId)
            {
                throw new NotFoundException(nameof(CarDTO), request.VehicleId);
            }

            _dbContext.Cars.Remove(car);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
