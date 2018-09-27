using System;

namespace Demo.AkkaNet.Gambling.Core.Commands
{
    public class GameDataGenerateMessage
    {
        public DateTime CreatedDateTime { get; }

        public GameDataGenerateMessage()
        {
            CreatedDateTime = DateTime.Now;
        }
    }
}