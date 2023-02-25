using MediatR;

namespace ServiceStation.BusinessLogic.RepairVehicle
{
    public class RepairVehicleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
