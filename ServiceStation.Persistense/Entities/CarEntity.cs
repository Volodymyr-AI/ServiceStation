using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain
{
    public class CarEntity : VehicleEntity
    { 
        public bool WheelBalancing { get; set; }
    }
}
