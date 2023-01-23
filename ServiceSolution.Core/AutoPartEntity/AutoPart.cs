using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSolution.Domain.AutoPartEntity
{
    public class AutoPart
    {
        public int WearRate { get; set; } // [0;100] 0 is fully broken 100 is a new detail
    }
}
