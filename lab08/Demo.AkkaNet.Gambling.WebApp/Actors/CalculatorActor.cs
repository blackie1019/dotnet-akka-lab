using System;
using Akka.Actor;
using Demo.AkkaNet.Gambling.Core;
using Demo.AkkaNet.Gambling.Core.Commands;

namespace Demo.AkkaNet.Gambling.WebApp.Actors
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<AddMessage>(add =>
            {
                Console.WriteLine($"{DateTime.Now}: Sum {add.Term1} + {add.Term2}");
                Sender.Tell(new AnswerMessage(add.Term1 + add.Term2));
            });
        }
    }
}