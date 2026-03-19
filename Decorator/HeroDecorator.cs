using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public class HeroDecorator : IHero
    {
        protected IHero _hero;
        public HeroDecorator(IHero hero)
        {
            _hero = hero;
        }

        public virtual string GetDescription() {
            return _hero.GetDescription();
        }

        public virtual int GetPower() {
            return _hero.GetPower();
        }
    }
}
