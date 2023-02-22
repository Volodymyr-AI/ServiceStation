using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQuery;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQueryHandler
{
    public class GetTruckQueryHandler : IRequestHandler<GetTruckQuery, TruckDetailsVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetTruckQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TruckDetailsVm> Handle(GetTruckQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Trucks.FirstOrDefaultAsync(truck => 
                    truck.Id == request.Id, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Truck), request.Id);
            }

            return _mapper.Map<TruckDetailsVm>(entity);
        }
    }
}
