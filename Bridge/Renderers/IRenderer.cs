using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Renderers
{
    public interface IRenderer
    {
        void Render(string shapeName);
    }
}
