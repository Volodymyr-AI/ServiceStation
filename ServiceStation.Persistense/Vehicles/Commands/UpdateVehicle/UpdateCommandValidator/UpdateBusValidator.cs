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
            RuleFor(updateCarValidator => updateCarValidator.Body).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Wheels).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Breaks).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Engine).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Undercarriage).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.InteriorAndHandrails).InclusiveBetween(0, 100);
        }
    }
}
