using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composer.Core;

namespace Composer.Iterator
{
    public class BreadthFirstIterator : ILightIterator
    {
        private Queue<LightNode> queue = new();

        public BreadthFirstIterator(LightNode root)
        {
            queue.Enqueue(root);
        }

        public bool HasNext()
        {
            return queue.Count > 0;
        }

        public LightNode Next()
        {
            var node = queue.Dequeue();

            if (node is LightElementNode element)
            {
                for (int i = 0; i < element.ChildrenCount; i++)
                {
                    queue.Enqueue(element.GetChild(i));
                }
            }

            return node;
        }
    }
}
