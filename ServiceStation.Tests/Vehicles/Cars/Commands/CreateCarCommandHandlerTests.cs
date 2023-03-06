using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Interfaces;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommandHandler;
using ServiceStation.Tests.Common;

namespace ServiceStation.Tests.Vehicles.Cars.Commands
{
    public class CreateCarCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateCarCommandHandler_Success()
        {
            //Arrange
            var handler = new CreateCarCommandHandler((IAppDbContext)Context);
            var carBody = 100;
            var carEngine = 100;
            var carBreaks = 100;
            var carWheels = 100;
            var carUndercarriage = 100;
            var carWheelBalancing = true;


            //Act
            var carId = await handler.Handle(
                new CreateCarCommand
                {
                    Body = carBody,
                    Engine = carEngine,
                    Breaks = carBreaks,
                    Wheels = carWheels,
                    Undercarriage = carUndercarriage,
                    WheelBalancing = carWheelBalancing
                },
                CancellationToken.None);
            //Assert
            Assert.NotNull(
                await Context.Cars.SingleOrDefaultAsync(car => 
                    car.Id == carId && car.Body == carBody && car.Breaks == carBreaks && car.Engine == carEngine && car.Undercarriage == carUndercarriage && car.Wheels == carWheels));
        }
    }
}
