using System;
using Akka.Actor;
using Demo.AkkaNet.MusicPlayer.Actors;
using Demo.AkkaNet.MusicPlayer.Messages;

namespace Demo.AkkaNet.MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef dispatcher = system.ActorOf<MusicPlayerCoordinatorActor>("player-coordinator");
            IActorRef stats = system.ActorOf<SongPerformanceActor>("statistics");
            
            DisplayActorInformation(dispatcher);
            DisplayActorInformation(stats);
            
            dispatcher.Tell(new UserPlaySongMessage("Smoke on the water", "Jeff"));
            dispatcher.Tell(new UserPlaySongMessage("Another brick in the wall", "Jed"));
            dispatcher.Tell(new UserPlaySongMessage("Another brick in the wall", "Blackie"));
            dispatcher.Tell(new UserPlaySongMessage("Flying to the moon", "Jeff"));
            
            dispatcher.Tell(new UserStopPlayingMessage("Jeff"));
            dispatcher.Tell(new UserStopPlayingMessage("Blackie"));

            dispatcher.Tell(new UserStopPlayingMessage("Jeff"));
            dispatcher.Tell(new UserPlaySongMessage("Another brick in the wall", "Jed"));
            dispatcher.Tell(new UserPlaySongMessage("Another brick in the wall", "Blackie"));
           
            Console.Read();

            system.Terminate();
        }
        
        static void DisplayActorInformation(IActorRef actor)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Actor's information:");
            Console.WriteLine($"Typed Actor named: {actor.Path.Name}");
            Console.WriteLine($"Actor's path: {actor.Path}");
            Console.WriteLine($"Actor's parent: {actor.Path.Parent.Name}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}
