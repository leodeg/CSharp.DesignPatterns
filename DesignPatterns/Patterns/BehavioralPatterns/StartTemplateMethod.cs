using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.BehavioralPatterns
{
    class StartTemplateMethod
    {
        public void Start ()
        {
            CaffeineBeverage coffee = new Coffee ();
            CaffeineBeverage tea = new Tea ();

            coffee.PrepareRecipe ();
            Console.WriteLine ();
            tea.PrepareRecipe ();
        }
    }

    public abstract class CaffeineBeverage
    {
        public void PrepareRecipe ()
        {
            BoilWater ();
            Brew ();
            PourInCup ();
            AddCondiments ();
        }

        public abstract void Brew ();
        public abstract void AddCondiments ();

        public void BoilWater ()
        {
            Console.WriteLine ("BoilWater");
        }

        public void PourInCup ()
        {
            Console.WriteLine ("PourInCup");
        }
    }

    public class Tea : CaffeineBeverage
    {
        public override void AddCondiments ()
        {
            Console.WriteLine ("Steeping the tea");
        }

        public override void Brew ()
        {
            Console.WriteLine ("Adding lemon");
        }
    }

    public class Coffee : CaffeineBeverage
    {
        public override void AddCondiments ()
        {
            Console.WriteLine ("Dripping Coffee through filter");
        }

        public override void Brew ()
        {
            Console.WriteLine ("Adding Sugar and Milk");
        }
    }
}
