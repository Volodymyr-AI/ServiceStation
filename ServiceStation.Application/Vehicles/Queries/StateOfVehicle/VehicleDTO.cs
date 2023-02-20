using AutoMapper;
using ServiceStation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Queries.StateOfVehicle
{
    public class VehicleDTO
    {
        public Guid Id { get; set; }
        public double State { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vehicle, VehicleDTO>()
                .ForMember(vehicleDto => vehicleDto.Id,
                    opt => opt.MapFrom(vehicle => vehicle.Id))
                .ForMember(vehicleDto => vehicleDto.State,
                    opt => opt.MapFrom(vehicle => vehicle.State));
        }
    }
}
