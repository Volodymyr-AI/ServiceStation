using Microsoft.EntityFrameworkCore;
using ServiceStation.Domain;
using ServiceStation.Persistense;

namespace ServiceStation.Tests.Common
{
    public class ServiceStationContextFactory
    {
        public static Guid CarIdForDelete = Guid.NewGuid();
        public static Guid CarIdForUpdate = Guid.NewGuid();

        public static AppDbContext Create()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new AppDbContext(options);
            context.Database.EnsureCreated();
            context.Cars.AddRange(
                new CarEntity
                {
                    Id = Guid.Parse("C0BB89CE-67DA-45E1-B83A-65FC9AFF9AA1"),
                    Body = 100,
                    Breaks = 90,
                    Wheels = 80,
                    Engine = 70,
                    Undercarriage = 60,
                    WheelBalancing = true
                },
                new CarEntity
                {
                    Id = Guid.Parse("B8CCE0FC-C53B-4207-8B80-4494B44CD551"),
                    Body = 100,
                    Breaks = 100,
                    Wheels = 100,
                    Engine = 100,
                    Undercarriage = 100,
                    WheelBalancing = false
                },
                new CarEntity
                {
                    Id = CarIdForDelete,
                    Body = 90,
                    Breaks = 90,
                    Wheels = 90,
                    Engine = 90,
                    Undercarriage = 90,
                    WheelBalancing = true
                },
                new CarEntity
                {
                    Id = CarIdForUpdate,
                    Body = 80,
                    Breaks = 80,
                    Wheels = 80,
                    Engine = 80,
                    Undercarriage = 80,
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
