using Proxy.TextReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.Proxies
{
    public class SmartTextChecker : ITextReader
    {
        private ITextReader _reader;
        public SmartTextChecker(ITextReader reader)
        {
            _reader = reader;
        }

        public char[][] Read(string filePath) {
            Console.WriteLine($"Opening file: {filePath}");
            char[][] content = _reader.Read(filePath);
            Console.WriteLine("File read successfully");

            int lines = content.Length;
            int chars = content.Sum(line => line.Length);
            Console.WriteLine($"Lines: {lines}");
            Console.WriteLine($"Characters: {chars}");
            return content;
        }
    }
}
