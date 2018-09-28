using System;

namespace Demo.AkkaNet.MusicPlayer.Exceptions
{
    class MusicSystemCorruptedException : Exception
    {
        public MusicSystemCorruptedException(string message): base(message)
        {
            Console.WriteLine(message);
        }
    }
}