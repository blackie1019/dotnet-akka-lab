using System;
using System.Collections.Generic;
using Akka.Actor;
using Demo.AkkaNet.MusicPlayer.Messages;

namespace Demo.AkkaNet.MusicPlayer.Actors
{
    public class SongPerformanceActor: ReceiveActor
    {
        protected Dictionary<string, int> SongPeformanceCounter;

        public SongPerformanceActor()
        {
            SongPeformanceCounter = new Dictionary<string, int>();
            Receive<PlaySongMessage>(m => IncreaseSongCounter(m));
        }

        public void IncreaseSongCounter(PlaySongMessage m)
        {
            var counter = 1;
            if (SongPeformanceCounter.ContainsKey(m.Song))
            {
                counter = SongPeformanceCounter[m.Song]++;
            }
            else
            {
                SongPeformanceCounter.Add(m.Song, counter);
            }
           
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Song: {m.Song} has been played {counter} times");
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}