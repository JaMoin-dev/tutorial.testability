using System.Collections.Generic;

namespace jamoin.demo.testability.startup.Utils
{
    public interface IFileProxy
    {
        void WriteAllLines(string path, IEnumerable<string> contents);
    }
}