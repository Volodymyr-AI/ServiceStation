using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommand
{
    public class CreateTruckCommand : CreateVehicleCommand
    {
        public int Hydraulics { get; set; }
    }
}
