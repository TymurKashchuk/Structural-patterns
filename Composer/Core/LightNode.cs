using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer.Core
{
    public abstract class LightNode
    {
        public abstract string OuterHTML();
        public abstract string InnerHTML();
    }
}
