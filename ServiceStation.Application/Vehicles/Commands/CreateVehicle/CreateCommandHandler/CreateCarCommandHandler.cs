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
        private ServiceStation.Persistense.AppDbContext context;

        public CreateCarCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public CreateCarCommandHandler(ServiceStation.Persistense.AppDbContext context)
        {
            this.context = context;
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
                WheelBalancing = request.WheelBalancing,
                State = (request.Body + request.Wheels + request.Engine + request.Breaks + request.Undercarriage) / 5.0
            };

            await _appDbContext.Cars.AddAsync(car, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);


            return car.Id;
        }
    }
}
