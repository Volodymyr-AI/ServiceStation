using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSolution.Core
{
    public abstract class Vehicle
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }

    }
}
