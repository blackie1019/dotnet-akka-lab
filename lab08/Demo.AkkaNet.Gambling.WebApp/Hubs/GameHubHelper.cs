using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Demo.AkkaNet.Gambling.Core.Commands;
using Akka.Actor;
using Demo.AkkaNet.Gambling.WebApp.Actors;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;

namespace Demo.AkkaNet.Gambling.WebApp.Hubs
{
    public class GameHubHelper: IHostedService, IDisposable
    {

        private readonly IHubContext<GameHub> _hub;

        public GameHubHelper(IHubContext<GameHub> hub)
        {
            _hub = hub;
        }

        internal async void UpdateGames(GameDataUpdateMessage msg)
        {
            var now = DateTime.Now;
            var ts =  now - msg.CreatedDateTime;
            Console.WriteLine($"Get Msg on {now.ToString("hh:mm:ss fff")}, diff(ms) ={ts.Milliseconds}");
            await _hub.Clients.All.SendAsync("updateGames", msg.GameData);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            AkkaStartupTasks.StartAkka();

            SystemActors.SignalRActor.Tell(new SignalRActor.SetHub(this));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            SystemActors.ActorSystem.Terminate();
            SystemActors.ActorSystem.Dispose();
        }
    }
}