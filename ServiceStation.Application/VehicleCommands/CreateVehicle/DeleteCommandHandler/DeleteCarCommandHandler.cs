using MediatR;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.VehicleCommands.CreateVehicle.DeleteCommand;
using ServiceStation.Domain;

namespace ServiceStation.Application.VehicleCommands.CreateVehicle.DeleteCommandHandler
{
    public class DeleteCarCommandHandler
    {
        private readonly IAppDbContext _dbContext;

        public DeleteCarCommandHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteVehicleCommand command, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Cars.FindAsync(new object[] { command.Id }, cancellationToken);

            if(entity == null || entity.Id != command.Id)
            {
                throw new NotFoundException(nameof(Car), command.Id);
            }

            _dbContext.Cars.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
