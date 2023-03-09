using AutoMapper;
using ServiceStation.API.Models.UpdateVehicleDtos;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCoommand;

namespace ServiceStation.API.Models.RepairVehicleDtos
{
    public class RepairBusDto : IMapWith<RepairBusCommand>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RepairBusDto, RepairBusCommand>()
                .ForMember(busCommand => busCommand.Id,
                            opt => opt.MapFrom(busDto => busDto.Id));
        }
    }
}
