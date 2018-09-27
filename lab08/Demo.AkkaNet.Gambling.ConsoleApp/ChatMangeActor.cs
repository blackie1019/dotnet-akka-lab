using System;
using Akka.Actor;
using Demo.AkkaNet.Gambling.Core.Commands;

namespace Demo.AkkaNet.Gambling.ConsoleApp
{
    public class ChatActor : TypedActor,
        IHandle<ConnectRequest>,
        IHandle<ConnectResponse>,
        IHandle<NickRequest>,
        IHandle<NickResponse>,
        IHandle<SayRequest>,
        IHandle<SayResponse>,
        IHandle<Terminated>, ILogReceive
    {
        private string _nick = "Blackie";

        private readonly ActorSelection _server =
            Context.ActorSelection("akka.tcp://MiniSportsbook@localhost:8081/user/FrontendServerActor"); 
        
        public void Handle(ConnectResponse message)
        {
            Console.WriteLine("Connected!");
            Console.WriteLine(message.Message);
        }

        public void Handle(NickRequest message)
        {
            message.OldUsername = this._nick;
            Console.WriteLine("Changing nick to {0}", message.NewUsername);
            this._nick = message.NewUsername;
            _server.Tell(message);
        }

        public void Handle(NickResponse message)
        {
            Console.WriteLine("{0} is now known as {1}", message.OldUsername, message.NewUsername);
        }

        public void Handle(SayResponse message)
        {
            Console.WriteLine("{0}: {1}", message.Username, message.Text);
        }

        public void Handle(ConnectRequest message)
        {
            Console.WriteLine("Connecting....");
            _server.Tell(message);
        }

        public void Handle(SayRequest message)
        {
            message.Username = this._nick;
            _server.Tell(message);
        }

        public void Handle(Terminated message)
        {
            Console.Write("Server died");
        }
    }
}