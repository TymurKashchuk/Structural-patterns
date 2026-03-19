using Decorator.Characters;
using Decorator.Inventory;

namespace Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHero hero = new Warrior();
            hero = new Sword(hero);
            hero = new Armor(hero);
            hero = new Artifact(hero);
            Console.WriteLine(hero.GetDescription());
            Console.WriteLine("Power: "+ hero.GetPower());

            IHero mage = new Mage();
            mage = new Artifact(new Artifact(mage));
            Console.WriteLine("\n" + mage.GetDescription());
            Console.WriteLine("Power: " + mage.GetPower());
        }
    }
}
