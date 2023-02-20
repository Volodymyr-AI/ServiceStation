using MediatR;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommandHandler
{
    public class CreateBusCommandHandler : IRequestHandler<CreateBusCommand, Guid>
    {
        private readonly IAppDbContext _appDbContext;

        public CreateBusCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Handle(CreateBusCommand request, CancellationToken cancellationToken)
        {
            var bus = new Bus
            {
                Id = Guid.NewGuid(),
                Body = request.Body,
                Wheels = request.Wheels,
                Engine = request.Engine,
                Breaks = request.Breaks,
                Undercarriage = request.Undercarriage,
                InteriorAndHandrails = request.InteriorAndHandrails
            };

            await _appDbContext.Buses.AddAsync(bus, cancellationToken);
            await _appDbContext.SaveChangesAsync(cancellationToken);


            return bus.Id;
        }
    }
}
