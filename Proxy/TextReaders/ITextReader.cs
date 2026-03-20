using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy.TextReaders
{
    public interface ITextReader
    {
        char[][] Read(string filePath);
    }
}
