using System.Collections.Generic;
using System.IO;

namespace jamoin.demo.testability.startup.Utils
{
    public class FileProxy : IFileProxy
    {
        public void WriteAllLines(string path, IEnumerable<string> contents)
        {
            File.WriteAllLines(path, contents);
        }
    }
}