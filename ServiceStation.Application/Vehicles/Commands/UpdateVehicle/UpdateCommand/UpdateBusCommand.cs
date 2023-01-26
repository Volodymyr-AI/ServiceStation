using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommand
{
    public class UpdateBusCommand : UpdateVehicleCommand
    {
        public int Interior { get; set; }
        public int Handrails { get; set; }
    }
}
