using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain
{
    public class BusEntity : VehicleEntity
    {
        public int InteriorAndHandrails { get; set; }
        public bool ChangeSeats { get; set; }
    }
}
