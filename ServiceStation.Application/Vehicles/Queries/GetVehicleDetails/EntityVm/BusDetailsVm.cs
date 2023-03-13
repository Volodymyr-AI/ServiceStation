using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm
{
    public class BusDetailsVm : IMapWith<Bus>
    {
        public Guid Id { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }
        public int Undercarriage { get; set; }
        public double Price { get; set; }
        //optional
        public int InteriorAndHandrails { get; set; }
        public bool ChangeSeats { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Bus, BusDetailsVm>()
                .ForMember(busvm => busvm.Body,
                    opt => opt.MapFrom(bus => bus.Body))
                .ForMember(busvm => busvm.Wheels,
                    opt => opt.MapFrom(bus => bus.Wheels))
                .ForMember(busvm => busvm.Engine,
                    opt => opt.MapFrom(bus => bus.Engine))
                .ForMember(busvm => busvm.Breaks,
                    opt => opt.MapFrom(bus => bus.Breaks))
                .ForMember(busvm => busvm.Undercarriage,
                    opt => opt.MapFrom(bus => bus.Undercarriage))
                //OPTIONAL
                .ForMember(busvm => busvm.InteriorAndHandrails,
                    opt => opt.MapFrom(bus => bus.InteriorAndHandrails))
                .ForMember(busvm => busvm.ChangeSeats,
                    opt => opt.MapFrom(bus => bus.ChangeSeats));
        }
    }
}
