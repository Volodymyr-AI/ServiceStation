using FluentValidation;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommandValidator
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
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
        }
    }
}
