using Proxy.TextReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Proxy.Proxies
{
    public class SmartTextReaderLocker : ITextReader
    {
        private ITextReader _reader;
        private Regex _regex;

        public SmartTextReaderLocker(ITextReader reader, string pattern)
        {
            _reader = reader;
            _regex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public char[][] Read(string filePath)
        {
            if (_regex.IsMatch(filePath))
            {
                Console.WriteLine("Access denied!");
                return new char[0][];
            }
            return _reader.Read(filePath);
        }
    }
}
