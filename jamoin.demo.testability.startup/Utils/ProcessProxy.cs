using System.Diagnostics;

namespace jamoin.demo.testability.startup.Utils
{
    public class ProcessProxy : IProcessProxy
    {
        public Process Start(string fileName)
        {
            return Process.Start(fileName);
        }
    }
}