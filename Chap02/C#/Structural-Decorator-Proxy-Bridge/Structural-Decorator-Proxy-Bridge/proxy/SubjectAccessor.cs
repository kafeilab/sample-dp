using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// The proxy pattern supports objects that control the creation of and access to other
// objects. The proxy is often a small (public) object that stands in for a more complex
// (private) object that is activated once certain circumstances are clear.
//
// There are several kinds of proxies, some are:
// - Virtual proxies: Hands the creation of an object over to another object
// - Authentication proxies: Checks that the access permissions for a request are correct
// - Remote proxies: Encodes requests and send them across a network
// - Smart proxies: Adds to or change requests before sending them on
namespace Structural_Decorator_Proxy_Bridge.proxy
{
    class SubjectAccessor
    {
        public interface ISubject { string Request(); }

        private class Subject { public string Request() => "Subject Request"; }

        public class Proxy : ISubject
        {
            Subject subject;

            // A virtual proxy creates the object only on its first method call
            public string Request()
            {
                if (subject == null)
                {
                    Console.WriteLine("Subject inactive");
                    subject = new Subject();
                }
                Console.WriteLine("Subject active");
                return "Proxy: Call to " + subject.Request();
            }
        }

        // An authentication proxy first asks for a password
        public class ProtectionProxy : ISubject
        {
            Subject subject;
            string password = "abracadabra";

            public string Authenticate(string supplied)
            {
                if (supplied != password)
                {
                    return "Protection Proxy: No access";
                } else
                {
                    subject = new Subject();
                    return "Protection Proxy: Authenticated";
                }
            }

            public string Request()
            {
                if (subject == null)
                {
                    return "Protection Proxy: Authenticate first";
                } else
                {
                    return "Protection Proxy: Call to " + subject.Request();
                }
            }
        }
    }

    class Client : SubjectAccessor
    {
        static void Main()
        {
            Console.WriteLine("Proxy Pattern\n");

            ISubject subject = new Proxy();
            Console.WriteLine(subject.Request());
            Console.WriteLine(subject.Request());

            subject = new ProtectionProxy();
            Console.WriteLine(subject.Request());
            Console.WriteLine((subject as ProtectionProxy).Authenticate("Secret"));
            Console.WriteLine((subject as ProtectionProxy).Authenticate("abracadabra"));
            Console.WriteLine(subject.Request());
            Console.ReadKey();
        }
    }
}
