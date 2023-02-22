using FluentValidation;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommandValidator
{
    public sealed class UpdateCarValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarValidator()
        {
            RuleFor(updateCarValidator =>
                    updateCarValidator.Id).NotEqual(Guid.Empty);

            RuleFor(updateCarValidator =>
                    updateCarValidator.Body)
                .GreaterThan(0)
                .LessThan(100);
            RuleFor(updateCarValidator =>
                   updateCarValidator.Wheels)
               .GreaterThan(0)
               .LessThan(100);
            RuleFor(updateCarValidator =>
                   updateCarValidator.Breaks)
               .GreaterThan(0)
               .LessThan(100);
            RuleFor(UpdateCarValidator => 
                    UpdateCarValidator.Engine)
                .GreaterThan(0)
                .LessThan(100);
            RuleFor(UpdateCarValidator =>
                    UpdateCarValidator.Undercarriage)
                .GreaterThan(0)
                .LessThan(100);
        }
    }
}
