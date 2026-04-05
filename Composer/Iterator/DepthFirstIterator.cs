using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composer.Core;

namespace Composer.Iterator
{
    public class DepthFirstIterator : ILightIterator
    {
        private Stack<LightNode> stack = new();

        public DepthFirstIterator(LightNode root)
        {
            stack.Push(root);
        }

        public bool HasNext()
        {
            return stack.Count > 0;
        }

        public LightNode Next()
        {
            var node = stack.Pop();

            if (node is LightElementNode element)
            {
                for (int i = element.ChildrenCount - 1; i >= 0; i--)
                {
                    stack.Push(element.GetChild(i));
                }
            }

            return node;
        }
    }
}
