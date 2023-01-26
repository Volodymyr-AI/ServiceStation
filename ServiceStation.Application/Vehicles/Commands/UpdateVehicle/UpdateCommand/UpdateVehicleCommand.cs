using MediatR;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommand
{
    public class UpdateVehicleCommand : IRequest
    {
        public Guid VehicleId { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Brakes { get; set; }
        public int Chassis { get; set; }

    }
}
