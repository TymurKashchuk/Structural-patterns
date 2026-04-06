using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composer.Core;

namespace Composer.Command
{
    public class AddChildCommand : ICommand
    {
        private LightElementNode parent;
        private LightNode child;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            this.parent = parent;
            this.child = child;
        }

        public void Execute() {
            parent.AddChild(child);
        }

        public void Undo() {
            parent.RemoveChild(child);
        }
    }
}
