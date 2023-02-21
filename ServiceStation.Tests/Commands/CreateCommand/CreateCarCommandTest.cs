using Microsoft.EntityFrameworkCore;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommand;
using ServiceStation.Application.Vehicles.VehicleCommands.CreateVehicle.CreateCommandHandler;
using ServiceStation.Persistense;

namespace ServiceStation.Tests.Commands.CreateCommand
{
    public class CreateCarCommandTest
    {
        [Fact]
        public async Task Handle_ValidRequest_CreatesNewCarAndReturnsId()
        {
            // Arrange
            //var options = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            //    .Options;
            //var dbContext = new AppDbContext(options);
            //var handler = new CreateCarCommandHandler(dbContext);
            //var request = new CreateCarCommand
            //{
            //    Body = 5,
            //    Wheels = 4,
            //    Engine = 6,
            //    Breaks = 7,
            //    Undercarriage = 8,
            //    WheelBalancing = true
            //};
            //
            //// Act
            //var result = await handler.Handle(request, CancellationToken.None);
            //
            //// Assert
            //Assert.NotEqual(default, result);
            //var car = await dbContext.Cars.FindAsync(result);
            //Assert.NotNull(car);
            //Assert.Equal(request.Body, car.Body);
            //Assert.Equal(request.Wheels, car.Wheels);
            //Assert.Equal(request.Engine, car.Engine);
            //Assert.Equal(request.Breaks, car.Breaks);
            //Assert.Equal(request.Undercarriage, car.Undercarriage);
            //Assert.Equal(request.WheelBalancing, car.WheelBalancing);
        }
    }
}
