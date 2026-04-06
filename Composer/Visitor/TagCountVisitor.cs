using Composer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer.Visitor
{
    public class TagCountVisitor : IVisitor
    {
        public int TagCount { get; private set; } = 0;

        public void VisitElement(LightElementNode element)
        {
            TagCount++;

            foreach (var child in element.GetChildren())
            {
                child.Accept(this);
            }
        }

        public void VisitText(LightTextNode textNode)
        {
            
        }
    }
}
