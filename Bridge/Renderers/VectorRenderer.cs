using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Renderers
{
    public class VectorRenderer : IRenderer
    {
        public void Render(string shapeName){
            Console.WriteLine($"Drawing {shapeName} as vectors");
        }
    }
}
