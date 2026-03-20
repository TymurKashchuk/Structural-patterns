using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    public class TagFactory
    {
        private Dictionary<string, TagFlyweight> _tags = new();

        public TagFlyweight GetTag(string tag, string display, bool selfClosing) { 
            string key = $"{tag}_{display}_{selfClosing}";

            if (!_tags.ContainsKey(key))
                _tags[key] = new TagFlyweight(tag, display, selfClosing);

            return _tags[key];
        }
        public int Count => _tags.Count;
    }
}
