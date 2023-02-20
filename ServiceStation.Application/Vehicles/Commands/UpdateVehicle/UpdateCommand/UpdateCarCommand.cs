using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand
{
    public class UpdateCarCommand : UpdateVehicleCommand
    {
        public bool WheelBalancing { get; set; }
    }
}
