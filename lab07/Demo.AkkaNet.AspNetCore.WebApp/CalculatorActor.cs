using Akka.Actor;
using Demo.AkkaNet.AspNetCore.WebApp.Messages;

namespace Demo.AkkaNet.AspNetCore.WebApp
{
    public class CalculatorActor : ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<AddMessage>(add =>
            {
                Sender.Tell(new AnswerMessage(add.Term1 + add.Term2));
            });
        }
    }
}