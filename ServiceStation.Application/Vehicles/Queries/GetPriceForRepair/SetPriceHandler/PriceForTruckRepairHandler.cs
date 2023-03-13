using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Queries.GetPriceForRepair.SetPrice;

namespace ServiceStation.Application.Vehicles.Queries.GetPriceForRepair.SetPriceHandler
{
    public class PriceForTruckRepairHandler : IRequestHandler<SetTruckPriceCommand, int>
    {
        private readonly IAppDbContext _context;

        public PriceForTruckRepairHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(SetTruckPriceCommand request, CancellationToken cancellationToken)
        {
            var truck = 
                await _context.Trucks.FirstOrDefaultAsync(truck => truck.Id == request.Id, cancellationToken);

            if (truck == null)
            {
                throw new NotFoundException(nameof(truck), request.Id);
            }

            int priceForRepair = 0;

            priceForRepair += ((100 - truck.Body) + (100 - truck.Breaks) + (100 - truck.Engine) + (100 - truck.Wheels) + (100 - truck.Hydraulics) + (100 - truck.Undercarriage));

            return priceForRepair;
        }
    }
}
