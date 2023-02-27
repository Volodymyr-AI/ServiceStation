using AutoMapper;
using ServiceStation.API.Models.CreateVehicleDtos;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;

namespace ServiceStation.API.Models.UpdateVehicleDtos
{
    public class UpdateCarDto : IMapWith<UpdateCarCommand>
    {
        public Guid Id { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }
        public int Undercarriage { get; set; }
        public bool WheelBalancing { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCarDto, UpdateCarCommand>()
                .ForMember(carCommand => carCommand.Id,
                            opt => opt.MapFrom(carDto => carDto.Id))
                .ForMember(carCommand => carCommand.Body,
                            opt => opt.MapFrom(carDto => carDto.Body))
                .ForMember(carCommand => carCommand.Wheels,
                            opt => opt.MapFrom(carDto => carDto.Wheels))
                .ForMember(carCommand => carCommand.Engine,
                            opt => opt.MapFrom(carDto => carDto.Engine))
                .ForMember(carCommand => carCommand.Breaks,
                            opt => opt.MapFrom(carDto => carDto.Breaks))
                .ForMember(carCommand => carCommand.Undercarriage,
                            opt => opt.MapFrom(carDto => carDto.Undercarriage))
                .ForMember(carCommand => carCommand.WheelBalancing,
                            opt => opt.MapFrom(carDto => carDto.WheelBalancing));
        }

    }
}
