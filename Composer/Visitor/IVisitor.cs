using Composer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer.Visitor
{
    public interface IVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode textNode);
    }
}
