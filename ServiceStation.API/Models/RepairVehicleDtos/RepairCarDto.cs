using AutoMapper;
using ServiceStation.API.Models.UpdateVehicleDtos;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCoommand;

namespace ServiceStation.API.Models.RepairVehicleDtos
{
    public class RepairCarDto : IMapWith<RepairCarCommand>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RepairCarDto, RepairCarCommand>()
                .ForMember(carCommand => carCommand.Id,
                            opt => opt.MapFrom(carDto => carDto.Id));
        }
    }
}
