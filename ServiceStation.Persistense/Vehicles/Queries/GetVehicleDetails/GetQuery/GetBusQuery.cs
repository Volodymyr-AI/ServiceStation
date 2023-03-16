using MediatR;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQuery
{
    public class GetBusQuery : GetVehicleQuery, IRequest<BusDetailsVm>
    {
    }
}
