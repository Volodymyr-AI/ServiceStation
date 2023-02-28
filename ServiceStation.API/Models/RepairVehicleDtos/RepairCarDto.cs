using AutoMapper;
using ServiceStation.API.Models.UpdateVehicleDtos;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using ServiceStation.BusinessLogic.RepairVehicle.RepairVehicleCoommand;

namespace ServiceStation.API.Models.RepairVehicleDtos
{
    public class RepairCarDto : IMapWith<RepairCarCommand>
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
            profile.CreateMap<RepairCarDto, RepairCarCommand>()
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
                            opt => opt.MapFrom(carDto => carDto.Undercarriage));
        }
    }
}
