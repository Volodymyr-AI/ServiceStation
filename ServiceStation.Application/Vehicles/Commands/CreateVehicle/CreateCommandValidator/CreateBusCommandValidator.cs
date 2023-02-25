using FluentValidation;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommandValidator
{
    public sealed class CreateBusCommandValidator : AbstractValidator<CreateBusCommand>
    {
        public CreateBusCommandValidator()
        {
            RuleFor(createBusCommand => createBusCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createBusCommand => createBusCommand.Body).InclusiveBetween(0, 100);
            RuleFor(createBusCommand => createBusCommand.Engine).InclusiveBetween(0, 100);
            RuleFor(createBusCommand => createBusCommand.Wheels).InclusiveBetween(0, 100);
            RuleFor(createBusCommand => createBusCommand.Undercarriage).InclusiveBetween(0, 100);
            RuleFor(createBusCommand => createBusCommand.Breaks).InclusiveBetween(0, 100);
            RuleFor(createBusCommand => createBusCommand.InteriorAndHandrails).InclusiveBetween(0, 100);
        }
    }
}
