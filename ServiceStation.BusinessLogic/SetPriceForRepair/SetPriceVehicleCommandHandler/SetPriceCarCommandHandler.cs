using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.Domain;
using System.Reflection;

namespace ServiceStation.BusinessLogic.SetPriceForRepair.SetPriceVehicleCommandHandler
{
    public class SetPriceCarCommandHandler : IRequestHandler<SetPriceVehicleCommand, int>
    {
        private readonly IAppDbContext _context;

        public SetPriceCarCommandHandler(IAppDbContext context) => _context = context;

        public async Task<int> Handle(SetPriceVehicleCommand request, CancellationToken cancellationToken)
        {
            var type = typeof(Car);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            //retrieve car from database
            var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == request.Id, cancellationToken);  

            int PriceForRepair = 0;

            foreach ( var property in properties)
            {
                if(property.PropertyType == typeof(int))
                {
                    var currentValue = (int)property.GetValue(car);
                    if(currentValue != 100)
                    {
                        var repairPrice = (100 - currentValue) * 10;
                        PriceForRepair += repairPrice;
                    }
                }
            }
            if(car.WheelBalancing == true)
            {
                return PriceForRepair + 100;
            }
            else
            {
                return PriceForRepair;
            }
            //return PriceForRepair;
        }
    }
}
