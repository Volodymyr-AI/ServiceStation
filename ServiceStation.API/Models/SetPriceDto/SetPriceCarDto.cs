using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.BusinessLogic.SetPriceForRepair;

namespace ServiceStation.API.Models.SetPriceDto
{
    public class SetPriceCarDto : IMapWith<SetPriceVehicleCommand>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SetPriceCarDto, SetPriceVehicleCommand>()
                .ForMember(carCommand => carCommand.Id,
                            opt => opt.MapFrom(carDto => carDto.Id));
        }
    }
}
