using MediatR;
namespace ServiceStation.Application.Vehicles.Commands.RepairVehicle.RepairCommand
{
    public class RepairVehicleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
