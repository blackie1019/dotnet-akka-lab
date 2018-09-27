using System;
using Akka.Actor;
using Demo.AkkaNet.HelloWorld.Actors;
using Demo.AkkaNet.HelloWorld.Messages;

namespace Demo.AkkaNet.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef untypedActor = system.ActorOf<MyUntypedActor>("untyped-actor-name");
            IActorRef typedActor = system.ActorOf<MyTypedActor>("typed-actor-name");

            untypedActor.Tell(new GreetingMessage("Hello untyped actor!"));
            typedActor.Tell(new GreetingMessage("Hello typed actor!"));
            
            Console.Read();
            system.Terminate();
        }
    }
}