using MediatR;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Domain;
using System.Reflection;

namespace ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommandHandler
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateCarCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var car = new CarEntity
            {
                Id = Guid.NewGuid(),
                Body = request.Body,
                Wheels = request.Wheels,
                Engine = request.Engine,
                Breaks = request.Breaks,
                Undercarriage = request.Undercarriage,
                WheelBalancing = request.WheelBalancing,
                State = (request.Body + request.Wheels + request.Engine + request.Breaks + request.Undercarriage) / 5.0
            };

            Math.Round(car.State, 2, MidpointRounding.AwayFromZero);

            await _appDbContext.Cars.AddAsync(car, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);


            return car.Id;
        }
    }
}
