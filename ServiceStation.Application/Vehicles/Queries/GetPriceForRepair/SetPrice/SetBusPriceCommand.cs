using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries.GetPriceForRepair.SetPrice
{
    public class SetBusPriceCommand : SetVehiclePriceCommand
    {
        public SetBusPriceCommand(Guid id)
        {
            Id = id;
        }
    }
}
