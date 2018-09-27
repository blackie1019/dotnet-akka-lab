using System;
using Akka.Actor;
using Demo.AkkaNet.Gambling.Core.Commands;
using Demo.AkkaNet.Gambling.WebApp.Hubs;

namespace Demo.AkkaNet.Gambling.WebApp.Actors
{
    public class SignalRActor: ReceiveActor, IWithUnboundedStash
    {
        #region Messages

        public class SetHub : INoSerializationVerificationNeeded
        {
            public SetHub(GameHubHelper hub)
            {
                Hub = hub;
            }
            public GameHubHelper Hub { get; }
        }

        #endregion

        private GameHubHelper _hub;

        public SignalRActor()
        {
            WaitingForHub();
        }

        private void HubAvailable()
        {

            Receive<GameDataUpdateMessage>(msg =>
            {
                _hub.UpdateGames(msg);
            });
        }

        private void WaitingForHub()
        {
            Receive<SetHub>(h =>
            {
                _hub = h.Hub;
                Become(HubAvailable);
                Stash.UnstashAll();
            });

            ReceiveAny(_ => Stash.Stash());
        }


        public IStash Stash { get; set; }
    }
}