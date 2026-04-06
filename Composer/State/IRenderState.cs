using Composer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer.State
{
    public interface IRenderState
    {
        string Render(LightElementNode node);
    }
}
