using System;
using System.Collections.Generic;
using Akka.Actor;
using Demo.AkkaNet.Gambling.Core;
using Demo.AkkaNet.Gambling.Core.Commands;

namespace Demo.AkkaNet.Gambling.WebApp.Actors
{
    public class ApiGameActor : ReceiveActor
    {
        public ApiGameActor()
        {
            Receive<GameDataUpdateMessage>(msg =>
            {
                var now = DateTime.Now;
                var ts =  now - msg.CreatedDateTime;
                Console.WriteLine($"Get Api pulling Msg on {now.ToString("hh:mm:ss fff")}, diff(ms) ={ts.Milliseconds}");
                Sender.Forward(msg.GameData);
            });
        }
    }
}