using Composer.Core;
using Composer.Iterator;
using Composer.Command;
using Composer.State;

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

            
            Console.WriteLine("\nDFS (глибина)");
            var dfs = new DepthFirstIterator(ul);
            while (dfs.HasNext())
            {
                Console.WriteLine(dfs.Next().OuterHTML());
            }

            Console.WriteLine("\nBFS (ширина)");
            var bfs = new BreadthFirstIterator(ul);
            while (bfs.HasNext())
            {
                Console.WriteLine(bfs.Next().OuterHTML());
            }

            Console.WriteLine("\nCOMMAND TEST");

            var invoker = new CommandInvoker();

            var newLi = new LightElementNode("li", "block", false);
            newLi.AddChild(new LightTextNode("Item 3"));

            var addCommand = new AddChildCommand(ul, newLi);

            invoker.Execute(addCommand);

            Console.WriteLine("after execute:");
            Console.WriteLine(ul.OuterHTML());

            invoker.Undo();

            Console.WriteLine("\nafter undo:");
            Console.WriteLine(ul.OuterHTML());

            Console.WriteLine("\nSTATE TEST");

            ul.SetRenderState(new PrettyState());

            Console.WriteLine("\nPretty HTML:");
            Console.WriteLine(ul.Render());

            ul.SetRenderState(new MinifiedState());

            Console.WriteLine("\nMinified HTML:");
            Console.WriteLine(ul.Render());
        }
    }
}
