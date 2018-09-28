using System;
using Akka.Actor;
using Demo.AkkaNet.MusicPlayer.Messages;

namespace Demo.AkkaNet.MusicPlayer.Actors
{
    public class UserMusicPlayerActor:ReceiveActor
    {
        private string CurrentSong = string.Empty;
        private string CurrentUser = string.Empty;
        
        public UserMusicPlayerActor()
        {
            StoppedBehavior();
        }

        private void StoppedBehavior()
        {
            Receive<UserPlaySongMessage>(m => PlaySong(m.Song, m.User));
            Receive<UserStopPlayingMessage>(m => Console.WriteLine($"User:{m.User} calling stop, but cannot stop, the actor is already stopped"));
        }

        private void PlayingBehavior()
        {
            Receive<UserPlaySongMessage>(m => Console.WriteLine($"User:{m.User} calling play, but cannot play. Currently playing '{CurrentSong} by User:{CurrentUser}'"));
            Receive<UserStopPlayingMessage>(m => StopPlaying(m.User));
        }

        private void PlaySong(string song,string user)
        {
            CurrentSong = song;
            CurrentUser = user;
            
            Console.WriteLine($"Currently playing '{CurrentSong} by User:{CurrentUser}'");
//            DisplayInformation();
            SendDataToStatistics(new PlaySongMessage(song));
            Become(PlayingBehavior);
        }

        private void StopPlaying(string userName)
        {
            CurrentSong = null;
            CurrentUser = null;
            
            Console.WriteLine($"Player:{userName} is currently stopped.");

            Become(StoppedBehavior);
        }

        private void SendDataToStatistics(PlaySongMessage msg)
        {
            var statsActor = Context.ActorSelection("../../statistics"); 
            statsActor.Tell(msg);
        }
       
    }
}