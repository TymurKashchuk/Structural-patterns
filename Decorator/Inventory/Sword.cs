using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator.Inventory
{
    public class Sword : HeroDecorator
    {
        public Sword(IHero hero) : base(hero)
        {
        }

        public override string GetDescription()
        {
            return _hero.GetDescription() + " + Sword";
        }

        public override int GetPower()
        {
            return _hero.GetPower() + 5;
        }
    }
}
