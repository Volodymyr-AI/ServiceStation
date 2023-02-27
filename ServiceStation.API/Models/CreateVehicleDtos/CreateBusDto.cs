using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;

namespace ServiceStation.API.Models.CreateVehicleDtos
{
    public class CreateBusDto : IMapWith<CreateBusCommand>
    {
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }
        public int Undercarriage { get; set; }
        public int InteriorAndHandrails { get; set; }
        public bool ChangeSeats { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBusDto, CreateBusCommand>()
                .ForMember(busCommand => busCommand.Body,
                            opt => opt.MapFrom(busDto => busDto.Body))
                .ForMember(busCommand => busCommand.Wheels,
                            opt => opt.MapFrom(busDto => busDto.Wheels))
                .ForMember(busCommand => busCommand.Engine,
                            opt => opt.MapFrom(busDto => busDto.Engine))
                .ForMember(busCommand => busCommand.Breaks,
                            opt => opt.MapFrom(busDto => busDto.Breaks))
                .ForMember(busCommand => busCommand.Undercarriage,
                            opt => opt.MapFrom(busDto => busDto.Undercarriage))
                .ForMember(busCommand => busCommand.InteriorAndHandrails,
                            opt => opt.MapFrom(busDto => busDto.InteriorAndHandrails))
                .ForMember(busCommand => busCommand.ChangeSeats,
                            opt => opt.MapFrom(busDto => busDto.ChangeSeats));
        }
    }
}
