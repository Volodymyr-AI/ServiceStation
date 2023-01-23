using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSolution.Domain.VehicleEntities
{
    public class Bus : Vehicle
    {
        public bool CheckInterior { get; set; }
        public bool CheckHandrails { get; set; }
    }
}
