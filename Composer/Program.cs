namespace Composer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ul = new LightElementNode("ul", "block",false);
            ul.AddClass("list");

            var li1 = new LightElementNode("li", "block", false);
            li1.AddChild(new LightTextNode("Item 1"));

            var li2 = new LightElementNode("li", "block", false);
            li2.AddChild(new LightTextNode("Item 2"));

            ul.AddChild(li1);
            ul.AddChild(li2);

            Console.WriteLine("OuterHTML:");
            Console.WriteLine(ul.OuterHTML());
            Console.WriteLine("\nInnerHTML:");
            Console.WriteLine(ul.InnerHTML());
            Console.WriteLine($"\nChildren count: {ul.ChildrenCount}");
        }
    }
}
