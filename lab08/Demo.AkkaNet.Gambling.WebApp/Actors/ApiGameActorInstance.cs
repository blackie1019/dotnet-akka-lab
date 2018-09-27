using System.Collections.Generic;
using System.Threading.Tasks;
using Akka.Actor;
using Demo.AkkaNet.Gambling.Core;
using Demo.AkkaNet.Gambling.Core.Commands;
using Demo.AkkaNet.Gambling.Core.ValueObjects;

namespace Demo.AkkaNet.Gambling.WebApp.Actors
{
    public class ApiGameActorInstance : IApiGameActorInstance {
        private IActorRef _actor;
        public ApiGameActorInstance(ActorSystem actorSystem) {
            _actor = actorSystem.ActorOf(Props.Create<ApiGameActor>(), "ApiGameActor");
        }

        public async Task<IEnumerable<MarketlineVO>> Reply(GameDataUpdateMessage message)
        {
            return await _actor.Ask<IEnumerable<MarketlineVO>>(message);
        }
    }
    
    public interface IApiGameActorInstance
    {
        Task<IEnumerable<MarketlineVO>> Reply(GameDataUpdateMessage message);
    }
}