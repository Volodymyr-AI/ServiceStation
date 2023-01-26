using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Persistence
{
    public class DbInitialize
    {
        public static void Initialize(StationDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
