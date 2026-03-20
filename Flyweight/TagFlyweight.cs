using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    public class TagFlyweight
    {
        public string TagName { get; }
        public string DisplayType { get; }
        public bool SelfClosing { get; }
        public TagFlyweight(string tagName, string displayType, bool selfClosing)
        {
            TagName = tagName;
            DisplayType = displayType;
            SelfClosing = selfClosing;
        }
    }
}
