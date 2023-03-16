using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm
{
    public class TruckDetailsVm : IMapWith<TruckEntity>
    {
        public Guid Id { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }
        public int Undercarriage { get; set; }
        public double State { get; set; }
        // optional
        public int Hydraulics { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TruckEntity, TruckDetailsVm>()
                .ForMember(truckvm => truckvm.Body,
                    opt => opt.MapFrom(truck => truck.Body))
                .ForMember(truckvm => truckvm.Wheels,
                    opt => opt.MapFrom(truck => truck.Wheels))
                .ForMember(truckvm => truckvm.Engine,
                    opt => opt.MapFrom(truck => truck.Engine))
                .ForMember(truckvm => truckvm.Breaks,
                    opt => opt.MapFrom(truck => truck.Breaks))
                .ForMember(truckvm => truckvm.Undercarriage, 
                    opt => opt.MapFrom(truck => truck.Undercarriage))
                .ForMember(truckvm => truckvm.State, 
                    opt => opt.MapFrom(truck => truck.State))
                //OPTIONAL
                .ForMember(truckvm => truckvm.Hydraulics, 
                    opt => opt.MapFrom(truck => truck.Hydraulics));
        }
    }
}
