using FluentValidation;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQuery;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQueryValidation
{
    public class GetVehicleQueryValidation : AbstractValidator<GetVehicleQuery>
    {
        public GetVehicleQueryValidation()
        {
            RuleFor(vehicle => vehicle.Id).NotEqual(Guid.Empty);
        }
    }
}
