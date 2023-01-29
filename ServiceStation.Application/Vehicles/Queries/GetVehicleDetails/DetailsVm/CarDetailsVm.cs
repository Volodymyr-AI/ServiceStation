using AutoMapper;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.DetailsVm
{
    public class CarDetailsVm : VehicleDetailsVm
    {
        public bool WheelBalancing { get; set; }

        public override void Mapping(Profile profile)
        {
            profile.CreateMap<Car, CarDetailsVm>()
                .ForMember(carvm => carvm.Body,
                    opt => opt.MapFrom(car => car.Body))
                .ForMember(carvm => carvm.Wheels,
                    opt => opt.MapFrom(car => car.Wheels))
                .ForMember(carvm => carvm.Engine,
                    opt => opt.MapFrom(car => car.Engine))
                .ForMember(carvm => carvm.Brakes,
                    opt => opt.MapFrom(car => car.Brakes))
                .ForMember(carvm => carvm.Chassis,
                    opt => opt.MapFrom(car => car.Chassis))
                .ForMember(carvm => carvm.AveragePoint,
                    opt => opt.MapFrom(car => car.AveragePoint))
                .ForMember(carvm => carvm.WheelBalancing,
                    opt => opt.MapFrom(car => car.WheelBalancing));
        }
    }
}
