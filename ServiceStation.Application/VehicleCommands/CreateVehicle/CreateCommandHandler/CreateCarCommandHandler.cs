using MediatR;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.VehicleCommands.CreateVehicle.CreateCommandHandler
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
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Body = request.Body,
                Wheels = request.Wheels,
                Engine = request.Engine,
                Breaks = request.Breaks,
                Undercarriage = request.Undercarriage,
                WheelBalancing = request.WheelBalancing
            };

            await _appDbContext.Cars.AddAsync(car, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);


            return car.Id;
        }
    }
}
