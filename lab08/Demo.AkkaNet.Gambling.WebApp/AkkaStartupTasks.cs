using Akka.Actor;
using Akka.Routing;
using Demo.AkkaNet.Gambling.Core;
using Demo.AkkaNet.Gambling.WebApp.Actors;

namespace Demo.AkkaNet.Gambling.WebApp
{
    public class AkkaStartupTasks
    {
        public static ActorSystem StartAkka()
        {
            // Akka.NET
            var hocon = HoconLoader.FromFile("akka.net.hocon");

            SystemActors.ActorSystem = ActorSystem.Create("MiniSportsbook", hocon);
            SystemActors.CommandProcessor =
                SystemActors.ActorSystem.ActorOf(Props.Create(() => new FrontendServerActor()), "FrontendServerActor");

            SystemActors.SignalRActor =
                SystemActors.ActorSystem.ActorOf(Props.Create(() => new SignalRActor()), "SignalRActor");

            return SystemActors.ActorSystem;
        }
    }
}