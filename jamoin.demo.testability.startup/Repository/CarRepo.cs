using System.Collections.Generic;
using jamoin.demo.testability.startup.Entities;

namespace jamoin.demo.testability.startup.Repository
{
    public static class CarRepo
    {
        /// <summary>
        /// loads all cars from DB
        /// </summary>
        public static List<Car> LoadAllCars()
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
