using System.Diagnostics;

namespace jamoin.demo.testability.startup.Utils
{
    public interface IProcessProxy
    {
        Process Start(string fileName);
    }
}