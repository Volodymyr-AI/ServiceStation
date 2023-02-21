using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.EntityVm
{
    public class CarDetailsVm : IMapWith<Car>
    {
        public Guid Id { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }
        public int Undercarriage { get; set; }
        public double State { get; set; }
        //OPTIONAL
        public bool WheelBalancing { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Car, CarDetailsVm>()
                .ForMember(carvm => carvm.Body,
                    opt => opt.MapFrom(car => car.Body))
                .ForMember(carvm => carvm.Wheels,
                    opt => opt.MapFrom(car => car.Wheels))
                .ForMember(carvm => carvm.Engine,
                    opt => opt.MapFrom(car => car.Engine))
                .ForMember(carvm => carvm.Breaks,
                    opt => opt.MapFrom(car => car.Breaks))
                .ForMember(carvm => carvm.Undercarriage,
                    opt => opt.MapFrom(car => car.Undercarriage))
                .ForMember(carvm => carvm.State,
                    opt => opt.MapFrom(car => car.State))
                //OPTIONAL
                .ForMember(carvm => carvm.WheelBalancing,
                    opt => opt.MapFrom(car => car.WheelBalancing));
        }

    }
}
