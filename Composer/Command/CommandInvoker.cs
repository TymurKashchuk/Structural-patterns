using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composer.Command
{
    public class CommandInvoker
    {
        private Stack<ICommand> history = new();

        public void Execute(ICommand command) {
            command.Execute();
            history.Push(command);
        }

        public void Undo() {
            if (history.Count > 0) {
                history.Pop().Undo();
            }
        }
    }
}
