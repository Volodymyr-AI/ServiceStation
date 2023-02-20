using MediatR;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommandHandler
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, Guid>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateTruckCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Truck
            {
                Id = Guid.NewGuid(),
                Body = request.Body,
                Wheels = request.Wheels,
                Engine = request.Engine,
                Breaks = request.Breaks,
                Undercarriage = request.Undercarriage,
                Hydraulics = request.Hydraulics
            };

            await _appDbContext.Trucks.AddAsync(truck, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);


            return truck.Id;
        }
    }
}
