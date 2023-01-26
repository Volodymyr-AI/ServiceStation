using MediatR;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommandHandler
{
    public class CreateBusCommandHandler : IRequestHandler<CreateBusCommand, Guid>
    {
        private readonly IStationDbContext _dbContext;

        public CreateBusCommandHandler(IStationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Handle(CreateBusCommand request, CancellationToken cancellationToken)
        {
            var bus = new Bus
            {
                VehicleId = Guid.NewGuid(),
                Body = request.Body,
                Wheels = request.Wheels,
                Engine = request.Engine,
                Brakes = request.Brakes,
                Chassis = request.Chassis,
                Interior = request.Interior,
                Handrails = request.Handrails,
                replacementOfInteriorSeatUpholstery = request.replacementOfInteriorSeatUpholstery
            };

            await _dbContext.Buses.AddAsync(bus, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return bus.VehicleId;
        }
    }
}
