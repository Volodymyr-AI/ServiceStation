using AutoMapper;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.DetailsVm
{
    public class TruckDetailsVm : VehicleDetailsVm
    {
        public int Hydraulics { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Truck, TruckDetailsVm>()
                .ForMember(truckvm => truckvm.Body,
                    opt => opt.MapFrom(truck => truck.Body))
                .ForMember(truckvm => truckvm.Wheels,
                    opt => opt.MapFrom(truck => truck.Wheels))
                .ForMember(truckvm => truckvm.Engine,
                    opt => opt.MapFrom(truck => truck.Engine))
                .ForMember(truckvm => truckvm.Brakes,
                    opt => opt.MapFrom(truck => truck.Brakes))
                .ForMember(truckvm => truckvm.Chassis,
                    opt => opt.MapFrom(truck => truck.Chassis))
                .ForMember(truckvm => truckvm.AveragePoint,
                    opt => opt.MapFrom(truck => truck.AveragePoint))
                .ForMember(truck => truck.Hydraulics,
                    opt => opt.MapFrom(truck => truck.Hydraulics));
        }
    }
}
