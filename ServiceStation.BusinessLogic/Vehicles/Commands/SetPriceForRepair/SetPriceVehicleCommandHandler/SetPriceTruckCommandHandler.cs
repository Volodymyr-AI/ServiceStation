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
    public class SetPriceTruckCommandHandler : IRequestHandler<SetPriceTruckCommand, int>
    {
        private readonly IAppDbContext _context;

        public SetPriceTruckCommandHandler(IAppDbContext context) => _context = context;

        public async Task<int> Handle(SetPriceTruckCommand request, CancellationToken cancellationToken)
        {
            var type = typeof(Car);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //retrieve car from database
            var truck = await _context.Trucks.FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

            int PriceForRepair = 0;

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(int))
                {
                    var currentValue = (int)property.GetValue(truck);
                    if (currentValue != 100)
                    {
                        var repairPrice = (100 - currentValue) * 10;
                        PriceForRepair += repairPrice;
                    }
                }
            }

            return PriceForRepair;
        }
    }
}
