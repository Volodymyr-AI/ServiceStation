using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCoommand
{
    public class RepairTruckCommand : RepairVehicleCommand
    {
        public int Hydraulics { get; set; }
    }
}
