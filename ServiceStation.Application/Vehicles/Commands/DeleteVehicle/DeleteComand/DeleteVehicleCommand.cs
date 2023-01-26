using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.DeleteVehicle.DeleteComand
{
    public class DeleteVehicleCommand : IRequest
    {
        public Guid VehicleId { get; set; }
    }
}
