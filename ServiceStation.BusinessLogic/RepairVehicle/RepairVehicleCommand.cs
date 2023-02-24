using MediatR;

namespace ServiceStation.BusinessLogic.RepairVehicle
{
    public class RepairVehicleCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
