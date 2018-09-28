using System;
using Akka.Actor;
using Demo.AkkaNet.MusicPlayer.Exceptions;
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
            Console.WriteLine($"User:{CurrentUser} player change to PlayingBehavior");
            Receive<UserPlaySongMessage>(m => Console.WriteLine($"User:{m.User} calling play, but cannot play. Because another song:'{CurrentSong}' is playing..."));
            Receive<UserStopPlayingMessage>(m => StopPlaying(m.User));
        }

        private void PlaySong(string song,string user)
        {
            CurrentSong = song;
            CurrentUser = user;

            CheckSongStatus(song);

            Console.WriteLine($"User:{CurrentUser} currently playing '{CurrentSong}'");
            
            SendDataToStatistics(new PlaySongMessage(song));
            Become(PlayingBehavior);
        }

        private void CheckSongStatus(string song)
        {
            switch (song)
            {
                case "天地":
                    throw new SongNotAvailableException("天地 is not available");
                case "新鴛鴦蝴蝶夢":
                    throw new MusicSystemCorruptedException("SystemCorrupted due to the song :新鴛鴦蝴蝶夢 is a sxxx....");
            }
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
            var statsActor = Context.ActorSelection("../../statistics"); //Absolute path: akka://my-first-akka/user/statistics
            statsActor.Tell(msg);
        }
       
    }
}