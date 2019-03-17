using System.Threading.Tasks;
using jamoin.demo.testability.startup.Entities;

namespace jamoin.demo.testability.startup.Utils
{
    public interface ICarLogger
    {
        Task LogAllCarsAsync(string path, params Car[] cars);
    }
}