using MediatR;
using ServiceStation.Domain;

namespace ServiceStation.Application.VehicleCommands.CreateVehicle.CreateCommand
{
    public class CreateVehicleCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }

        public int Undercarriage { get; set; }
    }
}
