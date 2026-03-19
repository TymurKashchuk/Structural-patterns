using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_patterns
{
    public class FileWriter
    {
        private string _filePath;
        public FileWriter(string filePath)
        {
            _filePath = filePath;
        }
        public void Write(string text)
        {
            File.AppendAllText(_filePath, text);
        }
        public void WriteLine(string text)
        {
            File.AppendAllText(_filePath, text + "\n");
        }
    }
}