using Composer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer.State
{
    public class MinifiedState : IRenderState
    {
        public string Render(LightElementNode node) {
            return node.OuterHTML()
                .Replace("\n", "")
                .Replace("\r", "");
        }
    }
}
