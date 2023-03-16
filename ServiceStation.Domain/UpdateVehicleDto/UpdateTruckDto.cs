using AutoMapper;
using ServiceStation.API.Models.CreateVehicleDtos;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;

namespace ServiceStation.API.Models.UpdateVehicleDtos
{
    public class UpdateTruckDto : IMapWith<UpdateTruckCommand>
    {
        public Guid Id { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }
        public int Undercarriage { get; set; }
        public int Hydraulics { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTruckDto, UpdateTruckCommand>()
                .ForMember(truckCommand => truckCommand.Id,
                            opt => opt.MapFrom(truckDto => truckDto.Id))
                .ForMember(truckCommand => truckCommand.Body,
                            opt => opt.MapFrom(truckDto => truckDto.Body))
                .ForMember(truckCommand => truckCommand.Wheels,
                            opt => opt.MapFrom(truckDto => truckDto.Wheels))
                .ForMember(truckCommand => truckCommand.Engine,
                            opt => opt.MapFrom(truckDto => truckDto.Engine))
                .ForMember(truckCommand => truckCommand.Breaks,
                            opt => opt.MapFrom(truckDto => truckDto.Breaks))
                .ForMember(truckCommand => truckCommand.Undercarriage,
                            opt => opt.MapFrom(truckDto => truckDto.Undercarriage))
                .ForMember(truckCommand => truckCommand.Hydraulics,
                            opt => opt.MapFrom(truckDto => truckDto.Hydraulics));
        }
    }
}
