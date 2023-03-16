using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Common;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm;
using ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQuery;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.GetQueryHandler
{
    public class GetBusQueryHandler : IRequestHandler<GetBusQuery, BusDetailsVm>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetBusQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BusDetailsVm> Handle(GetBusQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Buses.FirstOrDefaultAsync(bus => 
                   bus.Id == request.Id, cancellationToken);

            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(BusEntity), request.Id);
            }

            return _mapper.Map<BusDetailsVm>(entity);
        }
    }
}
