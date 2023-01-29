using AutoMapper;
using ServiceStation.Application.Common.Mappings;
using ServiceStation.Domain;

namespace ServiceStation.Application.Vehicles.Queries.GetVehicleDetails.DetailsVm
{
    public abstract class VehicleDetailsVm : IMapWith<Vehicle>
    {
        public Guid VehicleId { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Brakes { get; set; }
        public int Chassis { get; set; }
        public int AveragePoint { get; set; }

        public abstract void Mapping(Profile profile);
    }
}
