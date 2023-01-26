using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries
{
    public class GetVehicleDetailsQuery : IRequest<VehicleDetailVm>
    {
        public Guid VehicleId { get; set; }
    }
}
