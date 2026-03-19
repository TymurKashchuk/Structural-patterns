using Bridge.Renderers;
using Bridge.Shapes;

namespace Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRenderer vector = new VectorRenderer();
            IRenderer raster = new RasterRenderer();

            Shape circle = new Circle(vector);
            Shape square = new Square(raster);
            Shape triangle = new Triangle(raster);
            circle.Draw();
            square.Draw();
            triangle.Draw();
        }
    }
}
