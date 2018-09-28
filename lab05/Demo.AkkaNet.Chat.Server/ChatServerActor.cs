using System;
using System.Collections.Generic;
using Akka.Actor;
using Demo.AkkaNet.Chat.Core;

namespace Demo.AkkaNet.Chat.Server
{
    public class ChatServerActor : TypedActor,
        IHandle<SayRequest>,
        IHandle<ConnectRequest>,
        IHandle<NickRequest>,
        IHandle<Disconnect>,
        ILogReceive

    {
        private readonly HashSet<IActorRef> _clients = new HashSet<IActorRef>();

        public void Handle(SayRequest message)
        {
            Console.WriteLine("User {0} said {1}",message.Username , message.Text);
            var response = new SayResponse
            {
                Username = message.Username,
                Text = message.Text,
            };
            foreach (var client in _clients)
            {
                client.Tell(response, Self);
            }
        }

        public void Handle(ConnectRequest message)
        {
            Console.WriteLine("User {0} has connected", message.Username);
            _clients.Add(this.Sender);
            Sender.Tell(new ConnectResponse
            {
                Message = "Hello and welcome to Akka .NET chat example",
            }, Self);
        }

        public void Handle(NickRequest message)
        {
            Console.WriteLine("Receive Nick Reqest....");
            var response = new NickResponse
            {
                OldUsername = message.OldUsername,
                NewUsername = message.NewUsername,
            };

            foreach (var client in _clients)
            {
                client.Tell(response, Self);
            }
        }

        public void Handle(Disconnect message)
        {
            Console.WriteLine("Client Disconnect happen!");
        }
    }
}