using System;
using Akka.Actor;
using Demo.AkkaNet.Chat.Core;

namespace Demo.AkkaNet.Chat.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var hocon = HoconLoader.FromFile("akka.net.hocon");

            using (var system = ActorSystem.Create("MyServer", hocon))
            {
                system.ActorOf<ChatServerActor>("ChatServer");
                Console.WriteLine("Server is Ready!");
                Console.ReadLine();
            }
        }
    }
}