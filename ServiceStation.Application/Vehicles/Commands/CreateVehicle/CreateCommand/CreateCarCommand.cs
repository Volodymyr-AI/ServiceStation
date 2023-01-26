using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommand
{
    public class CreateCarCommand : CreateVehicleCommand
    {
        public bool WheelBalancing { get; set; }
    }
}
