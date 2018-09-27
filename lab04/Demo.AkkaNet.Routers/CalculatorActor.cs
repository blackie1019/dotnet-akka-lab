using System;
using Akka.Actor;

namespace Demo.AkkaNet.Routers
{
    public class CalculatorActor : ReceiveActor 
    {
        public CalculatorActor()
        {
            Receive<Add>(add => HandleAddition(add)); }
        public void HandleAddition(Add add)
        {
            Console.WriteLine($"{Self.Path} received the request: {add.Term1}+{add.Term2}");
            Sender.Tell(new Answer(add.Term1 + add.Term2)) ; }
    }
}