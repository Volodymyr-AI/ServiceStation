using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand
{
    public class UpdateVehicleCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int Body { get; set; }
        public int Wheels { get; set; }
        public int Engine { get; set; }
        public int Breaks { get; set; }

        public int Undercarriage { get; set; }
    }
}
