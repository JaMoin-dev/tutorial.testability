using System.IO;
using System.Linq;
using System.Threading.Tasks;
using jamoin.demo.testability.startup.Entities;
using jamoin.demo.testability.startup.Utils;

namespace jamoin.demo.testability.startup
{
    public class CarLogger : ICarLogger
    {
        public async Task LogAllCarsAsync(string path, params Car[] cars)
        {
            var locContent = cars.Select(c => $"Drehzahl: {c.RevolutionsPerMinute}/m - Speed: {c.MaxSpeed}km/h");
            await Task.Run(() => File.WriteAllLines(path, locContent));
        }
    }
}