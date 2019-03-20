using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using jamoin.demo.testability.startup.Entities;
using jamoin.demo.testability.startup.Utils;

namespace jamoin.demo.testability.startup
{
    public class CarLogger : ICarLogger
    {
        private readonly IFileProxy _fileProxy;

        public CarLogger(IFileProxy fileProxy)
        {
            _fileProxy = fileProxy;
        }

        public async Task LogAllCarsAsync(string path, params Car[] cars)
        {
            var locContent = cars.Select(c => $"Drehzahl: {c.RevolutionsPerMinute}/m - Speed: {c.MaxSpeed}km/h");
            await Task.Run(() => _fileProxy.WriteAllLines(path, locContent));
        }
    }

    
}