using System.IO;
using System.Linq;
using System.Threading.Tasks;
using jamoin.demo.testability.startup.Entities;

namespace jamoin.demo.testability.startup
{
    public static class CarLogger
    {
        public static async Task LogAllCarsAsync(string path, params Car[] cars)
        {
            var locContent = cars.Select(c => $"Drehzahl: {c.RevolutionsPerMinute}/m - Speed: {c.MaxSpeed}km/h");
            await Task.Run(() => File.WriteAllLines(path, locContent));
        }
    }
}