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
            RuleFor(createVehicleCommand =>
                    createVehicleCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createVehicleCommand =>
                    createVehicleCommand.Body)
                .LessThan(100)
                .GreaterThan(0);
            RuleFor(createVehicleCommand =>
                    createVehicleCommand.Engine)
                .LessThan(100)
                .GreaterThan(0);
            RuleFor(createVehicleCommand =>
                    createVehicleCommand.Wheels)
                .LessThan(100)
                .GreaterThan(0);
            RuleFor(createVehicleCommand =>
                    createVehicleCommand.Undercarriage)
                .LessThan(100)
                .GreaterThan(0);
            RuleFor(createVehicleCommand =>
                    createVehicleCommand.Breaks)
                .LessThan(100)
                .GreaterThan(0);
            RuleFor(createTruckCommand => 
                    createTruckCommand.Hydraulics)
                .LessThan(100)
                .GreaterThan(0);
        }
    }
}
