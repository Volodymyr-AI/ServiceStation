using ServiceStation.Domain;

namespace ServiceStation.API.IRepository
{
    public interface ICarRepository
    {
        Car GetCarQuery(Guid id);
        void CreateCarCommand(Car car); 
        void UpdateCarCommand(Car car);
        void RepairCarCommand(Guid id);

        void SetCarPriceCommand(Guid id, double price);
    }
}
