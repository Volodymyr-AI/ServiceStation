using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.Vehicles.Commands.SetPriceForRepair.SetPriceVehicle;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BusinessLogic.Vehicles.Commands.SetPriceForRepair.SetPriceVehicleCommandHandler
{
    public class SetPriceBusCommandHandler : IRequestHandler<SetPriceBusCommand, int>
    {
        private readonly IAppDbContext _context;

        public SetPriceBusCommandHandler(IAppDbContext context) => _context = context;

        public async Task<int> Handle(SetPriceBusCommand request, CancellationToken cancellationToken)
        {
            var type = typeof(Bus);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //retrieve bus from database
            var bus = await _context.Buses.FirstOrDefaultAsync(bus => bus.Id == request.Id, cancellationToken);

            int PriceForRepair = 0;

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(int))
                {
                    var currentValue = (int)property.GetValue(bus);
                    if (currentValue != 100)
                    {
                        var repairPrice = (100 - currentValue) * 10;
                        PriceForRepair += repairPrice;
                    }
                }
            }
            if (bus.ChangeSeats == true)
            {
                return PriceForRepair + 300;
            }
            else
            {
                return PriceForRepair;
            }
            //return PriceForRepair;
        }
    }
}
