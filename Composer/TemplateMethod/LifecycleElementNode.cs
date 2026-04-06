using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composer.Core;

namespace Composer.TemplateMethod
{
    public class LifecycleElementNode : LightElementNode
    {
        public LifecycleElementNode(string tagName, string displayType, bool selfClosing)
            : base(tagName, displayType, selfClosing)
        {
        }

        public override string OuterHTML()
        {
            OnCreated();

            string html = base.OuterHTML();

            OnRendered();

            return html;
        }

        protected virtual void OnCreated()
        {
            Console.WriteLine($"Element created: {_tagName}");
        }

        protected virtual void OnRendered()
        {
            Console.WriteLine($"Element rendered: {_tagName}");
        }
    }
}
