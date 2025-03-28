using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter, the client can call its method.");
            Console.WriteLine(target.GetRequest());
        }
    }
}
