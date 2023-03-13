using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommandHandler
{
    public class UpdateBusCommandHandler : IRequestHandler<UpdateBusCommand, Guid>
    {
        private IAppDbContext _appDbContext;

        public UpdateBusCommandHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Guid> Handle(UpdateBusCommand request, CancellationToken cancellationToken)
        {
            var entity =
               await _appDbContext.Buses.FirstOrDefaultAsync(bus =>
                            bus.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Bus), request.Id);
            }

            entity.Engine = request.Engine;
            entity.Wheels = request.Wheels;
            entity.Breaks = request.Breaks;
            entity.Undercarriage = request.Undercarriage;
            entity.Body = request.Body;
            //optional only for bus
            entity.InteriorAndHandrails = request.InteriorAndHandrails;
            entity.ChangeSeats = request.ChangeSeats;
            entity.State = (request.Engine + request.Wheels + request.Breaks + request.Undercarriage + request.Body + request.InteriorAndHandrails) / 6.0;


            Math.Round(entity.State, 2, MidpointRounding.AwayFromZero);

            await _appDbContext.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
