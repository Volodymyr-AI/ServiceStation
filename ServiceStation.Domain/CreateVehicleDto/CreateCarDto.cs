using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;

namespace ServiceStation.API.Models.CreateVehicleDtos
{
    public class CreateCarDto : IMapWith<CreateCarCommand>
    {
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }
        public int Undercarriage { get; set; }

        public bool WheelBalancing { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCarDto, CreateCarCommand>()
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
