using MediatR;

namespace ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCoommand
{
    public class RepairVehicleCommand : IRequest<string>
    {
        public Guid Id { get; set; }
    }
}
