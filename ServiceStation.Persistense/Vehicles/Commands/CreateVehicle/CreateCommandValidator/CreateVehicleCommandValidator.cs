using FluentValidation;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;

namespace ServiceStation.Application.Vehicles.Commands.CreateVehicle.CreateCommandValidator
{
    public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
    {
        public CreateVehicleCommandValidator()
        {
            RuleFor(createVehicleCommand =>  createVehicleCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createVehicleCommand => createVehicleCommand.Body).InclusiveBetween(0, 100);
            RuleFor(createVehicleCommand => createVehicleCommand.Engine).InclusiveBetween(0, 100);
            RuleFor(createVehicleCommand => createVehicleCommand.Wheels).InclusiveBetween(0, 100);
            RuleFor(createVehicleCommand => createVehicleCommand.Undercarriage).InclusiveBetween(0, 100);
            RuleFor(createVehicleCommand => createVehicleCommand.Breaks).InclusiveBetween(0, 100);
        }
    }
}
