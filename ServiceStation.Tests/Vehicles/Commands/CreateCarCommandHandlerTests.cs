using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommandHandler;
using ServiceStation.Tests.Common;

namespace ServiceStation.Tests.Vehicles.Commands
{
    public class CreateCarCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCarCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateCarCommandHandler(Context);

            //Act
            var carId = await handler.Handle(
                new CreateCarCommand
                {
                    Body = 100,
                    Breaks = 100,
                    Engine = 100,
                    Wheels = 100,
                    Undercarriage = 100,
                    WheelBalancing = true
                }, CancellationToken.None);
            //Assert
            Assert.NotNull(
                await Context.Cars.SingleOrDefaultAsync(car =>
                    car.Id == carId && car.Body == 100 && car.Breaks == 100 && car.Engine == 100 && car.Wheels == 100 && car.Undercarriage == 100 && car.WheelBalancing == true));
        }
    }
}
