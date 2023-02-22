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
    public class GetCarQueryHandler : IRequestHandler<GetCarQuery, CarDetailsVm>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GetCarQueryHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<CarDetailsVm> Handle(GetCarQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _appDbContext.Cars.FirstOrDefaultAsync(car =>
                    car.Id == request.Id, cancellationToken);

            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Car), request.Id);
            }

            return _mapper.Map<CarDetailsVm>(entity);
        }
    }
}
