using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.BusinessLogic.SetPriceForRepair;

namespace ServiceStation.API.Models.SetPriceDto
{
    public class SetPriceBusDto : IMapWith<SetPriceVehicleCommand>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SetPriceBusDto, SetPriceVehicleCommand>()
                .ForMember(busCommand => busCommand.Id,
                            opt => opt.MapFrom(busDto => busDto.Id));
        }
    }
}
