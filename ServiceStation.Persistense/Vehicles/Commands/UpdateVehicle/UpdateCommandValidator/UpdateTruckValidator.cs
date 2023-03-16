using FluentValidation;
using ServiceStation.Application.Vehicles.VehicleCommands.UpdateVehicle.UpdateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.Application.Vehicles.Commands.UpdateVehicle.UpdateCommandValidator
{
    public class UpdateTruckValidator : AbstractValidator<UpdateTruckCommand>
    {
        public UpdateTruckValidator()
        {
            RuleFor(updateTruckValidator =>
                    updateTruckValidator.Id).NotEqual(Guid.Empty);

            RuleFor(updateCarValidator => updateCarValidator.Body).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Wheels).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Breaks).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Engine).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Undercarriage).InclusiveBetween(0, 100);
            RuleFor(updateCarValidator => updateCarValidator.Hydraulics).InclusiveBetween(0, 100);
        }
    }
}
