using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand
{
    public class CreateTruckCommand : CreateVehicleCommand
    {
        public int Hydraulics { get; set; }
    }
}
