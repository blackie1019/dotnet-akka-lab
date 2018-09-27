using Akka.Actor;

namespace Demo.AkkaNet.Gambling.WebApp.Actors
{
    public class SystemActors
    {
        public static ActorSystem ActorSystem;

        public static IActorRef SignalRActor = ActorRefs.Nobody;

        public static IActorRef CommandProcessor = ActorRefs.Nobody;
    }
}