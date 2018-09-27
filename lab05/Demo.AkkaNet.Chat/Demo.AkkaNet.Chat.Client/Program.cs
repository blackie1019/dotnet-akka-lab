using System;
using System.Linq;
using Akka.Actor;
using Demo.AkkaNet.Chat.Core;

namespace Demo.AkkaNet.Chat.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var hocon = HoconLoader.FromFile("akka.net.hocon");

            using (var system = ActorSystem.Create("MyClient", hocon))
            {
                var chatClient = system.ActorOf(Props.Create<ChatClientActor>());
                chatClient.Tell(new ConnectRequest()
                {
                    Username = "Blackie",
                });

                while (true)
                {
                    var input = Console.ReadLine();
                    if (input.StartsWith("/"))
                    {
                        var parts = input.Split(' ');
                        var cmd = parts[0].ToLowerInvariant();
                        var rest = string.Join(" ", parts.Skip(1));

                        if (cmd == "/nick")
                        {
                            chatClient.Tell(new NickRequest
                            {
                                NewUsername = rest
                            });
                        }

                        if (cmd == "/exit")
                        {
                            Console.WriteLine("exiting");
                            break;
                        }
                    }
                    else
                    {
                        chatClient.Tell(new SayRequest()
                        {
                            Text = input,
                        });
                    }
                }

                system.Terminate().Wait();
            }
        }
    }
}