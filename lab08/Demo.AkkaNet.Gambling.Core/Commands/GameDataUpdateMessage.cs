using System;
using System.Collections.Generic;
using Demo.AkkaNet.Gambling.Core.ValueObjects;

namespace Demo.AkkaNet.Gambling.Core.Commands
{
    public class GameDataUpdateMessage
    {
        public DateTime CreatedDateTime { get; }
        public IEnumerable<MarketlineVO>  GameData { get; }
        public GameDataUpdateMessage(DateTime dateTime, IEnumerable<MarketlineVO> data)
        {
            CreatedDateTime = dateTime;
            GameData = data;
        }
    }
}