using MediatR;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommandHandler
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, Guid>
    {
        private readonly IStationDbContext _dbContext;

        public CreateTruckCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Truck
            {
                VehicleId = Guid.NewGuid(),
                Body = request.Body,
                Wheels = request.Wheels,
                Engine = request.Engine,
                Brakes = request.Brakes,
                Chassis = request.Chassis,
                Hydraulics= request.Hydraulics
            };

            await _dbContext.Trucks.AddAsync(truck, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return truck.VehicleId;
        }
    }
}
