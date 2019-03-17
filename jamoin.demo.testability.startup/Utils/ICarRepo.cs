using System.Collections.Generic;
using jamoin.demo.testability.startup.Entities;

namespace jamoin.demo.testability.startup.Utils
{
    public interface ICarRepo
    {
        List<Car> LoadAllCars();
    }
}