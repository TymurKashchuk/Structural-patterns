using Bridge.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Shapes
{
    public class Circle : Shape
    {
        public Circle(IRenderer renderer) : base(renderer)
        {
        }

        public override void Draw()
        {
            _renderer.Render("Circle");
        }
    }
}
