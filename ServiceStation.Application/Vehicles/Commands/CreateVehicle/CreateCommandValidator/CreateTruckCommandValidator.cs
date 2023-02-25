using FluentValidation;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommandValidator
{
    public sealed class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
    {
        public CreateTruckCommandValidator()
        {
            RuleFor(createTruckCommand => createTruckCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createTruckCommand => createTruckCommand.Body).InclusiveBetween(0, 100);
            RuleFor(createTruckCommand => createTruckCommand.Engine).InclusiveBetween(0, 100);
            RuleFor(createTruckCommand => createTruckCommand.Wheels).InclusiveBetween(0, 100);
            RuleFor(createTruckCommand => createTruckCommand.Undercarriage).InclusiveBetween(0, 100);
            RuleFor(createTruckCommand => createTruckCommand.Breaks).InclusiveBetween(0, 100);
            RuleFor(createTruckCommand => createTruckCommand.Hydraulics).InclusiveBetween(0, 100);
        }
    }
}
