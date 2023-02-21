using MediatR;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQuery
{
    public class GetCarQuery : GetVehicleQuery, IRequest<CarDetailsVm>
    {
    }
}
