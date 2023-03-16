using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Queries.GetPriceForRepair.SetPrice;

namespace ServiceStation.Application.Vehicles.Queries.GetPriceForRepair.SetPriceHandler
{
    internal class PriceForBusRepairHandler : IRequestHandler<SetBusPriceCommand, int>
    {
        private readonly IAppDbContext _context;

        public PriceForBusRepairHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(SetBusPriceCommand request, CancellationToken cancellationToken)
        {
            var bus = 
                await _context.Buses.FirstOrDefaultAsync(bus => bus.Id == request.Id, cancellationToken);

            if (bus == null)
            {
                throw new NotFoundException(nameof(bus), request.Id);
            }

            int priceForRepair = 0;

            priceForRepair += ((100 - bus.Body) + (100 - bus.Breaks) + (100 - bus.Wheels) + (100 - bus.Undercarriage) + (100 - bus.Engine) + (100 - bus.InteriorAndHandrails)) * 10;

            if(bus.ChangeSeats == true)
            {
                priceForRepair += 300;
            }

            return priceForRepair;
        }
    }
}
