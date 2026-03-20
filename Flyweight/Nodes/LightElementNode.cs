using Flyweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    public class LightElementNode : LightNode
    {
        private TagFlyweight _tag;
        private List<LightNode> _children = new();

        public LightElementNode(TagFlyweight tag)
        {
            _tag = tag;
        }

        public void AddChild(LightNode node)
        {
            _children.Add(node);
        }

        public override string InnerHTML()
        {
            StringBuilder sb = new();

            foreach (var child in _children)
                sb.Append(child.OuterHTML());

            return sb.ToString();
        }

        public override string OuterHTML()
        {
            if (_tag.SelfClosing)
                return $"<{_tag.TagName}/>";

            return $"<{_tag.TagName}>{InnerHTML()}</{_tag.TagName}>";
        }
    }
}
