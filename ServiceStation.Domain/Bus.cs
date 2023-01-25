using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Domain
{
    public class Bus : Vehicle
    {
        public int Interior { get; set; }
        public int Handrails { get; set; }

        public bool replacementOfInteriorSeatUpholstery { get; set; } // optional
    }
}
