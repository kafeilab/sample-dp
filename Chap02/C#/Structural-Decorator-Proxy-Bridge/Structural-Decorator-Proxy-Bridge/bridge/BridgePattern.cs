using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structural_Decorator_Proxy_Bridge.bridge
{
    // The Bridge pattern decouples an abstraction from its implementation,
    // enabling them to vary independently
    
    // DESIGN
    // Abstraction: The interface that the client sees
    // Operation: A method that is called by the client
    // Bridge: An interface defining those parts of the Abstraction that might vary
    // ImplemenationA and ImplementationB: Implementations of the Bridge interface
    // OperationImp: A method in the Bridge that is called from the Operation in the Abstraction
    class BridgePattern
    {
        class Abstraction
        {
            Bridge bridge;

            public Abstraction(Bridge bridge)
            {
                this.bridge = bridge;
            }

            public string Operation()
            {
                return "Abstraction: <<<Bridge>>> " + bridge.OperationImpl();
            }
        }

        interface Bridge { string OperationImpl(); }

        class ImplementationA : Bridge
        {
            public string OperationImpl()
            {
                return "Implementation A";
            }
        }

        class ImplementationB : Bridge
        {
            public string OperationImpl()
            {
                return "Implementation B";
            }
        }

        static void Main()
        {
            Console.WriteLine("Bridge Pattern\n");

            Console.WriteLine(new Abstraction(new ImplementationA()).Operation());
            Console.WriteLine(new Abstraction(new ImplementationB()).Operation());
            Console.ReadKey();
        }
    }
}
