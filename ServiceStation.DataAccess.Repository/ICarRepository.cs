using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.DataAccess.Repository
{
    public interface ICarRepository
    {
        CarEntity GetById(Guid id);
        void Add(CreateCarDto carDto);
        void Update(UpdateCarDto updateDto);
        void SetPrice(SetPriceDto setPriceDto);
        void RepairCar(RepairCarDto repairDto);
    }
}
