using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.VehicleCommands.CreateVehicle.DeleteCommand
{
    public class DeleteVehicleCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
