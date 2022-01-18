using System.Collections.Generic;
using System.IO;

namespace Lab4.Shared
{
    public class Reader
    {
        private readonly IEnumerable<string> fileNames;

        public Reader(IEnumerable<string> fileNames)
        {
            this.fileNames = fileNames;
        }

        public IEnumerable<(string fileName, string content)> Read()
        {
            foreach (var fileName in fileNames)
            {
                yield return (fileName, File.ReadAllText($"texts/{fileName}"));
            }
        }
    }
}
