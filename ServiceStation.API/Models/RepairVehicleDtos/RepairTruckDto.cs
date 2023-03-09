using AutoMapper;
using ServiceStation.API.Models.UpdateVehicleDtos;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.BusinessLogic.Vehicles.Commands.RepairVehicle.RepairVehicleCoommand;

namespace ServiceStation.API.Models.RepairVehicleDtos
{
    public class RepairTruckDto : IMapWith<RepairTruckCommand>
    {
        public Guid Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<RepairTruckDto, RepairTruckCommand>()
                .ForMember(truckCommand => truckCommand.Id,
                            opt => opt.MapFrom(truckDto => truckDto.Id));
        }
    }
}
