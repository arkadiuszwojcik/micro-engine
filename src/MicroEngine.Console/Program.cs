using MicroEngine.Core;
using System;

namespace MicroEngine.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Actor a = new Actor();
            var actor = ActorUtils.CreateActor<Actor>();
            System.Console.WriteLine("Hello World!");
        }
    }
}