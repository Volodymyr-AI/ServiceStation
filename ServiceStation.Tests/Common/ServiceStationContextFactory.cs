using Microsoft.EntityFrameworkCore;
using ServiceStation.Persistense;
using ServiceStation.Domain;

namespace ServiceStation.Tests.Common
{
    public class ServiceStationContextFactory
    {
        public static Guid CarIdForDelete = Guid.NewGuid();
        public static Guid CarIdForUpdate = Guid.NewGuid();

        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            context.Cars.AddRange(
                    new Car
                    {
                        Id = Guid.Parse("0DE7501F-6241-4994-8276-53414183FDC4"),
                        Body = 75,
                        Wheels = 80,
                        Engine = 90,
                        Undercarriage = 56,
                        Breaks = 67,
                        WheelBalancing = true
                    },
                    new Car
                    {
                        Id = Guid.Parse("41901F87-86E7-4BAB-984F-5465EC716B58"),
                        Body = 100,
                        Wheels = 100,
                        Engine = 100,
                        Undercarriage = 100,
                        Breaks = 100,
                        WheelBalancing = false
                    },
                    new Car
                    {
                        Id = CarIdForDelete,
                        Body = 12,
                        Wheels = 12,
                        Engine = 12,
                        Undercarriage = 12,
                        Breaks = 12,
                        WheelBalancing = false
                    },
                    new Car
                    {
                        Id = CarIdForUpdate,
                        Body = 15,
                        Wheels = 15,
                        Engine = 15,
                        Undercarriage = 15,
                        Breaks = 15,
                        WheelBalancing = false
                    }
                );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(AppDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
