using System;
using Akka.Actor;
using Demo.AkkaNet.Gambling.Core;
using Demo.AkkaNet.Gambling.Core.Commands;
using Demo.AkkaNet.Gambling.Core.Utilities;

namespace Demo.AkkaNet.Gambling.ConsoleApp
{
    public class GameMangeActor : TypedActor,
        IHandle<ConnectRequest>,
        IHandle<ConnectResponse>,
        IHandle<GameDataGenerateMessage>,
        IHandle<Terminated>, ILogReceive
    {
        private string _nick = "Blackie";

        private readonly ActorSelection _server =
            Context.ActorSelection("akka.tcp://MiniSportsbook@localhost:8081/user/SignalRActor");
        
        public void Handle(GameDataGenerateMessage message)
        {
            _server.Tell(new GameDataUpdateMessage(message.CreatedDateTime,GameHelper.GenerateMaketlines()));
        }
        
        public void Handle(ConnectResponse message)
        {
            Console.WriteLine("Connected!");
            Console.WriteLine(message.Message);
        }

        public void Handle(ConnectRequest message)
        {
            Console.WriteLine("Connecting....");
            _server.Tell(message);
        }

        public void Handle(Terminated message)
        {
            Console.Write("Server died");
        }
    }
}