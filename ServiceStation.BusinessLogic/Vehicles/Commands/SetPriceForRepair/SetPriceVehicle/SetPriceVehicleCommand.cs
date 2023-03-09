using MediatR;

namespace ServiceStation.BusinessLogic.Vehicles.Commands.SetPriceForRepair.SetPriceVehicle
{
    public class SetPriceVehicleCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
