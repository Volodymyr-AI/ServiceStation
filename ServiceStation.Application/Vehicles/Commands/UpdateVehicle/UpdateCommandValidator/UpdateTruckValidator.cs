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

            RuleFor(updateTruckValidator =>
                    updateTruckValidator.Body)
                .GreaterThan(0)
                .LessThan(100);
            RuleFor(updateTruckValidator =>
                   updateTruckValidator.Wheels)
               .GreaterThan(0)
               .LessThan(100);
            RuleFor(updateTruckValidator => 
                    updateTruckValidator.Breaks)
               .GreaterThan(0)
               .LessThan(100);
            RuleFor(UpdateTruckValidator =>
                    UpdateTruckValidator.Engine)
                .GreaterThan(0)
                .LessThan(100);
            RuleFor(UpdateTruckValidator =>
                    UpdateTruckValidator.Undercarriage)
                .GreaterThan(0)
                .LessThan(100);
            RuleFor(UpdateTruckValidator =>
                    UpdateTruckValidator.Hydraulics)
                .GreaterThan(0)
                .LessThan(100);
        }
    }
}
