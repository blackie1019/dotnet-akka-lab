using Akka.Actor;
using Demo.AkkaNet.HelloWorld.Messages;

namespace Demo.AkkaNet.HelloWorld.Actors
{
    public class CalculatorActor: ReceiveActor
    {
        public CalculatorActor()
        {
            Receive<AddMessage>(input =>
            {
                Sender.Tell(new AnswerMessage(input.Term1+input.Term2));
            });
        }
    }
}