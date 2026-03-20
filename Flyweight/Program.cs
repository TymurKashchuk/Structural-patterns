namespace Flyweight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var factory = new TagFactory();

            var root = new LightElementNode(factory.GetTag("div", "block", false));

            string[] lines = File.ReadAllLines("book.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                LightElementNode element;

                if (i == 0)
                {
                    element = new LightElementNode(factory.GetTag("h1", "block", false));
                }
                else if (line.Length < 20)
                {
                    element = new LightElementNode(factory.GetTag("h2", "block", false));
                }
                else if (line.StartsWith(" "))
                {
                    element = new LightElementNode(factory.GetTag("blockquote", "block", false));
                }
                else
                {
                    element = new LightElementNode(factory.GetTag("p", "block", false));
                }

                element.AddChild(new LightTextNode(line));
                root.AddChild(element);
            }

            Console.WriteLine("Generated HTML:\n");
            Console.WriteLine(root.OuterHTML());

            Console.WriteLine("\nUnique tag objects (Flyweight): " + factory.Count);
            Console.WriteLine("Total nodes in tree: " + lines.Length);
        }
    }
}
