using FluentValidation;
using MediatR;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommandValidator
{
    public sealed class UpdateBusValidator : AbstractValidator<UpdateBusCommand>
    {
        public UpdateBusValidator()
        {
            RuleFor(updateBusValidator =>
                    updateBusValidator.Id).NotEqual(Guid.Empty);
            RuleFor(updateBusValidator => updateBusValidator.Body)
                .GreaterThan(0)
                .LessThan(100);
            RuleFor(updateBusValidator => updateBusValidator.Wheels)
               .GreaterThan(0)
               .LessThan(100);
            RuleFor(updateBusValidator => updateBusValidator.Breaks)
               .GreaterThan(0)
               .LessThan(100);
            RuleFor(updateBusValidator => updateBusValidator.Engine)
                .GreaterThan(0)
                .LessThan(100);
            RuleFor(updateBusValidator => updateBusValidator.Undercarriage)
                .GreaterThan(0)
                .LessThan(100);
            RuleFor(updateBusValidator => updateBusValidator.InteriorAndHandrails)
                .GreaterThan(0)
                .LessThan(100);
        }
    }
}
