using System;
using Akka.Actor;
using Demo.AkkaNet.HelloWorld.Messages;

namespace Demo.AkkaNet.HelloWorld.Actors
{
    public class MyTypedActor : ReceiveActor
    {
        public MyTypedActor()
        {
            Receive<GreetingMessage>(message =>
            {
                GreetingMessageHandler(message);
                GreetingMessageHandler2(message);
                GreetingMessageHandler3(message);
            });
            Receive<GreetingMessage>(message =>
            {
                GreetingMessageHandler2(message);
            });
            Receive<GreetingMessage>(message =>
            {
                GreetingMessageHandler3(message);
            });
            ReceiveAny( obj => Console.WriteLine($"!!! This is handle by ReceiveAny method. Input is: {obj} !!!"));
        }

        private void GreetingMessageHandler(GreetingMessage greeting)
        {
            Console.WriteLine($"Typed Actor named: {Self.Path.Name}");
            Console.WriteLine($"Received a greeting: {greeting.Greeting}");
            Console.WriteLine($"Actor's path: {Self.Path}");
            Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name}");
        }
        
        private void GreetingMessageHandler2(GreetingMessage greeting)
        {
            Console.WriteLine($" GreetingMessageHandler2 Received a greeting: {greeting.Greeting}");
        }
        
        private void GreetingMessageHandler3(GreetingMessage greeting)
        {
            Console.WriteLine($" GreetingMessageHandler3 Received a greeting: {greeting.Greeting}");
        }
    }
}