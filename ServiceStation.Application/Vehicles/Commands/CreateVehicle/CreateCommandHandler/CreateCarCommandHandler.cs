using MediatR;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommandHandler
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
    {
        private readonly IStationDbContext _dbContext;

        public CreateCarCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new Car
            {
                VehicleId = Guid.NewGuid(),
                Body = request.Body,
                Wheels = request.Wheels,
                Engine = request.Engine,
                Brakes = request.Brakes,
                Chassis = request.Chassis,
                WheelBalancing = request.WheelBalancing
            };

            await _dbContext.Cars.AddAsync(car, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return car.VehicleId;
        }
    }
}
