using System;
using System.Collections.Generic;
using Akka.Actor;
using Demo.AkkaNet.MusicPlayer.Messages;

namespace Demo.AkkaNet.MusicPlayer.Actors
{
    public class SongStatisticsActor: ReceiveActor
    {
        protected Dictionary<string, int> SongStatisticsCounter;

        public SongStatisticsActor()
        {
            SongStatisticsCounter = new Dictionary<string, int>();
            Receive<PlaySongMessage>(m => IncreaseSongCounter(m));
        }

        public void IncreaseSongCounter(PlaySongMessage m)
        {
            var counter = 1;
            if (SongStatisticsCounter.ContainsKey(m.Song))
            {
                counter = ++SongStatisticsCounter[m.Song];
            }
            else
            {
                SongStatisticsCounter.Add(m.Song, counter);
            }
           
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Song: {m.Song} has been played {counter} times");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}