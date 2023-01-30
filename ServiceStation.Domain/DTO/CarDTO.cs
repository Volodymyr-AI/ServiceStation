using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain.DTO
{
    public class CarDTO : VehicleDTO
    {
        public bool WheelBalancing { get; set; } // optional
    }
}
