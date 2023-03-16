using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Queries.GetPriceForRepair.SetPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries.GetPriceForRepair.SetPriceHandler
{
    public class PriceForCarRepairHandler : IRequestHandler<SetCarPriceCommand, int>
    {
        private readonly IAppDbContext _context;

        public PriceForCarRepairHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(SetCarPriceCommand request, CancellationToken cancellationToken)
        {
            var car = await _context.Cars.FirstOrDefaultAsync(car => car.Id == request.Id, cancellationToken);

            int priceForRepair = 0;

            if (car == null)
            {
                throw new NotFoundException(nameof(car), request.Id);
            }

            priceForRepair = ((100 - car.Body) + (100 - car.Breaks) + (100 - car.Wheels) + (100 - car.Engine) + (100 - car.Undercarriage)) * 10;
            if(car.WheelBalancing == true)
            {
                priceForRepair += 100;
            }
            return priceForRepair;
        }
    }
}
