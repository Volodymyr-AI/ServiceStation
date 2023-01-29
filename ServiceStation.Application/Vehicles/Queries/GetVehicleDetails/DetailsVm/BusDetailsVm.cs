using AutoMapper;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.DetailsVm
{
    public class BusDetailsVm : VehicleDetailsVm
    {
        public int Interior { get; set; }
        public int Handrails { get; set; }

        public bool replacementOfInteriorSeatUpholstery { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Bus, BusDetailsVm>()
                .ForMember(busvm => busvm.Body,
                    opt => opt.MapFrom(bus => bus.Body))
                .ForMember(busvm => busvm.Wheels,
                    opt => opt.MapFrom(bus => bus.Wheels))
                .ForMember(busvm => busvm.Engine,
                    opt => opt.MapFrom(bus => bus.Engine))
                .ForMember(busvm => busvm.Brakes,
                    opt => opt.MapFrom(bus => bus.Brakes))
                .ForMember(busvm => busvm.Chassis,
                    opt => opt.MapFrom(bus => bus.Chassis))
                .ForMember(busvm => busvm.AveragePoint,
                    opt => opt.MapFrom(bus => bus.AveragePoint))
                .ForMember(busvm => busvm.Interior,
                    opt => opt.MapFrom(bus => bus.Interior))
                .ForMember(busvm => busvm.Handrails,
                    opt => opt.MapFrom(bus => bus.Handrails))
                .ForMember(busvm => busvm.replacementOfInteriorSeatUpholstery,
                    opt => opt.MapFrom(bus => bus.replacementOfInteriorSeatUpholstery));
        }
    }
}
