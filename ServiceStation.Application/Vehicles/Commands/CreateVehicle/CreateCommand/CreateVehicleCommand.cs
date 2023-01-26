using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommand
{
    public class CreateVehicleCommand : IRequest<Guid>
    {
        public Guid VehicleId { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Brakes { get; set; }
        public int Chassis { get; set; }
    }
}
