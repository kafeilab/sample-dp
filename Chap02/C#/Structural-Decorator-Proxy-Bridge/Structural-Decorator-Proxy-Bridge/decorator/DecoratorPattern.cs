using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Decorator_Proxy_Bridge.decorator
{
    // The role of the Decorator pattern is to provide a way of attaching new state
    // and behavior to an object dynamically. A key implementation point in the
    // Decorator pattern is that decorators both inherit the original class and 
    // contain an instantiation of it.
    class DecoratorPattern
    {

        interface IComponent
        {
            string Operation();
        }

        class Component : IComponent
        {
            public string Operation()
            {
                return "I am walking ";
            }
        }

        class DecoratorA : IComponent
        {
            IComponent component;

            public DecoratorA(IComponent component)
            {
                this.component = component;
            }

            public string Operation()
            {
                string s = component.Operation();
                return s += "and listening to Classic FM";
            }
        }

        // This Decorator has added some state and added some bebahior
        class DecoratorB : IComponent
        {
            IComponent component;
            public string addedState = "past the Coffee Shop";

            public DecoratorB(IComponent component)
            {
                this.component = component;
            }

            public string Operation()
            {
                string s = component.Operation();
                return s += "to school ";
            }

            public string AddedBehavior()
            {
                return " and I bought a cappuccino";
            }
        }

        class Client
        {
            static void Display(string s, IComponent component)
            {
                Console.WriteLine(s + component.Operation());
            }

            static void Main()
            {
                Console.WriteLine("Decorator Pattern\n");

                IComponent component = new Component();
                Display("1. Basic component: ", component);
                Display("2. A-decorated: ", new DecoratorA(component));
                Display("3. B-decorated: ", new DecoratorB(component));
                Display("4. B-A-decorated: ", new DecoratorB(new DecoratorA(component)));

                DecoratorB b = new DecoratorB(new Component());
                Display("5. A-B-decorated: ", new DecoratorA(b));

                // Invoking its added state and added behavior
                Console.WriteLine("\t\t\t" + b.addedState + b.AddedBehavior());
                Console.ReadKey();
            }
        }

    }
}
