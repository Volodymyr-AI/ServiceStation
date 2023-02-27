using MediatR;

namespace ServiceStation.BusinessLogic.SetPriceForRepair
{
    public class SetPriceVehicleCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}
