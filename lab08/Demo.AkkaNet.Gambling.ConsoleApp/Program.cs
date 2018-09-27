using System;
using System.Linq;
using Akka.Actor;
using Demo.AkkaNet.Gambling.Core;
using Demo.AkkaNet.Gambling.Core.Commands;

namespace Demo.AkkaNet.Gambling.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var hocon = HoconLoader.FromFile("akka.net.hocon");
            var system = ActorSystem.Create("GameManagementClient", hocon);
            
//            SwitchToChat(system);
              SwitchToGame(system);
        }

        static void SwitchToChat(ActorSystem system)
        {
            var client = system.ActorOf(Props.Create<ChatActor>());
            client.Tell(new ConnectRequest()
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
                        client.Tell(new NickRequest
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
                    client.Tell(new SayRequest()
                    {
                        Text = input,
                    });
                }
                
            }
            system.Terminate().Wait();
        }
        
        static void SwitchToGame(ActorSystem system)
        {
            var client = system.ActorOf(Props.Create<GameMangeActor>());
            client.Tell(new ConnectRequest()
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

                    if (cmd == "/game")
                    {
                        system
                            .Scheduler
                            .ScheduleTellRepeatedly(TimeSpan.FromSeconds(0),
                                TimeSpan.FromMilliseconds(200),
                                client, new GameDataGenerateMessage(), ActorRefs.NoSender);
                    }

                    if (cmd == "/exit")
                    {
                        Console.WriteLine("exiting");
                        break;
                    }
                }
            }
            system.Terminate().Wait();
        }
    }
}