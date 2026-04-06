using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composer.State;

namespace Composer.Core
{
    public class LightElementNode : LightNode
    {
        private string _tagName;
        private string _displayType;
        private bool _selfClosing;
        private List<string> _classes = new List<string>();
        private List<LightNode> _children = new List<LightNode>();
        private IRenderState _renderState;

        public LightElementNode(string tagName, string displayType, bool selfClosing)
        {
            _tagName = tagName;
            _displayType = displayType;
            _selfClosing = selfClosing;
        }

        public void AddClass(string className)
        {
            _classes.Add(className);
        }

        public void AddChild(LightNode node)
        {
            _children.Add(node);
        }

        public int ChildrenCount => _children.Count;

        public LightNode GetChild(int index)
        {
            return _children[index];
        }

        public void RemoveChild(LightNode node)
        {
            _children.Remove(node);
        }

        public void SetRenderState(IRenderState state)
        {
            _renderState = state;
        }
        public override string InnerHTML()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var child in _children)
            {
                sb.Append(child.OuterHTML());
            }

            return sb.ToString();
        }

        public override string OuterHTML()
        {
            StringBuilder sb = new StringBuilder();

            string classAttr = _classes.Count > 0
                ? $" class=\"{string.Join(" ", _classes)}\""
                : "";

            if (_selfClosing)
            {
                sb.Append($"<{_tagName}{classAttr}/>");
            }
            else
            {
                sb.Append($"<{_tagName}{classAttr}>");
                sb.Append(InnerHTML());
                sb.Append($"</{_tagName}>");
            }

            return sb.ToString();
        }

        public string Render() {
            if (_renderState == null)
                return OuterHTML();

            return _renderState.Render(this);
        }
    }
}
