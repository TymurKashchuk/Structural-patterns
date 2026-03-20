using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.TextReaders
{
    public class SmartTextReader : ITextReader
    {
        public char[][] Read(string filePath) {
            string[] lines = File.ReadAllLines(filePath);
            return lines.Select(line => line.ToCharArray()).ToArray();
        }
    }
}
