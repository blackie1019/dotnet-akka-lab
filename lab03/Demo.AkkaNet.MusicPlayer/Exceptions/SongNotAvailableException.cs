using System;

namespace Demo.AkkaNet.MusicPlayer.Exceptions
{
    public class SongNotAvailableException : Exception
    {
        public SongNotAvailableException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}