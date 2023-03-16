using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand
{
    public class CreateBusCommand : CreateVehicleCommand
    {
        public int InteriorAndHandrails { get; set; }
        public bool ChangeSeats { get; set; }
    }
}
