using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Characters
{
    public class Warrior : IHero
    {
        public string GetDescription() => "Warrior";
        public int GetPower() => 10;
    }
}
