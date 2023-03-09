using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.BusinessLogic.Vehicles.Commands.SetPriceForRepair.SetPriceVehicle;
using ServiceStation.Domain;
using System.Reflection;

namespace ServiceStation.BusinessLogic.Vehicles.Commands.SetPriceForRepair.SetPriceVehicleCommandHandler
{
    public class SetPriceCarCommandHandler : IRequestHandler<SetPriceCarCommand, int>
    {
        private readonly IAppDbContext _context;

        public SetPriceCarCommandHandler(IAppDbContext context) => _context = context;

        public async Task<int> Handle(SetPriceCarCommand request, CancellationToken cancellationToken)
        {
            var type = typeof(Car);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //retreive from database
            var car = 
                await _context.Cars.FirstOrDefaultAsync(car => car.Id == request.Id , cancellationToken);

            int setPriceForRepair = 0;

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(int))
                {
                    var currentValue = (int)property.GetValue(car);
                    if (currentValue != 100)
                    {
                        var repairPrice = (100 - currentValue) * 10;
                        setPriceForRepair += repairPrice;
                    }
                }
            }

            if(car.WheelBalancing == true)
            {
                setPriceForRepair += 100;
                return setPriceForRepair;
            }
            return setPriceForRepair;
        }
    }
}
