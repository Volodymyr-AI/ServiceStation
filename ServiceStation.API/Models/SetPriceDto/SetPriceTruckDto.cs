using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.BusinessLogic.SetPriceForRepair;

namespace ServiceStation.API.Models.SetPriceDto
{
    public class SetPriceTruckDto : IMapWith<SetPriceVehicleCommand>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SetPriceTruckDto, SetPriceVehicleCommand>()
                .ForMember(truckCommand => truckCommand.Id,
                            opt => opt.MapFrom(truckDto => truckDto.Id));
        }
    }
}
