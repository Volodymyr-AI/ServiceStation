using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Common
{
    public class NotFoundException : Exception
    {
        //Custom exception to identify not found entity
        public NotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) not found")
        { }
    }
}
