using System.Threading.Tasks;
using Akka.Actor;
using Demo.AkkaNet.Gambling.Core;
using Demo.AkkaNet.Gambling.Core.Commands;

namespace Demo.AkkaNet.Gambling.WebApp.Actors
{
    public class CalculatorActorInstance : ICalculatorActorInstance {
        private IActorRef _actor;
        public CalculatorActorInstance(ActorSystem actorSystem) {
            _actor = actorSystem.ActorOf(Props.Create<CalculatorActor>(), "Calculator");
        }
        public async Task<AnswerMessage> Sum(AddMessage message) {
            return await _actor.Ask<AnswerMessage>(message); }
    }
    
    public interface ICalculatorActorInstance
    {
        Task<AnswerMessage> Sum(AddMessage message);
    }
}