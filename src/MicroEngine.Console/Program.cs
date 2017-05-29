using MicroEngine.Core;
using System;

namespace MicroEngine.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectFactory factory = new ObjectFactory();
            var actor = factory.CreateActor<Actor>();
            actor.Some(4, null);
            System.Console.WriteLine("Hello World!");
        }
    }
}