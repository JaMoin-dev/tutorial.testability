using System.Collections.Generic;
using jamoin.demo.testability.startup.Entities;
using jamoin.demo.testability.startup.Utils;

namespace jamoin.demo.testability.startup.Repository
{
    public class CarRepo : ICarRepo
    {
        /// <summary>
        /// loads all cars from DB
        /// </summary>
        public List<Car> LoadAllCars()
        {
            //using (var db = new CarDbContext())
            //{
            //    return db.Cars.ToList();
            //}

            return new List<Car>()
            {
                new Car()
                {
                    MaxTransmission = 0.03,
                    WheelSize = 1,
                    RevolutionsPerMinute = 3000
                },
                new Car()
                {
                    MaxTransmission = 0.03,
                    WheelSize = 1,
                    RevolutionsPerMinute = 3000
                }
            };
        }
    }
}
