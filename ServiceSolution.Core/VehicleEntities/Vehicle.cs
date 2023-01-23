using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSolution.Domain.VehicleEntities
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }
        public bool CheckBody { get; set; }
        public bool CheckWheels { get; set; }
        public bool CheckEngine { get; set; }
        public bool CheckBrakes { get; set; }
        public bool CheckChessis { get; set; }



    }
}
