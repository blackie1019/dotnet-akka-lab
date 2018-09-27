using System;
using System.Collections.Generic;
using System.Linq;
using Demo.AkkaNet.Gambling.Core.ValueObjects;

namespace Demo.AkkaNet.Gambling.Core.Utilities
{
    public class GameHelper
    {
        private static readonly string[] TeamNames = new[]
        {
            "Los Angeles Lakers", "Golden State Warriors",
            "Boston Celtics", "Milwaukee bucks",
            "Cleveland Cavaliers", "Philadelphia 76ers"
        };

        private static decimal[][] GenerateOdds()
        {
            var result = new decimal[3][];
            
            var rng = new Random(Guid.NewGuid().GetHashCode());
            for (var i = 0; i < 3; i++)
            {
                var rngValue = (rng.Next(1, 90) / 100.0) * 100 / 100;

                var oddsA = 1m + Convert.ToDecimal(rngValue);
                var oddsB = 3.8m - oddsA;

                result[i] = new[] {oddsA, oddsB};
            }

            ;

            return result;
        }

        public static IEnumerable<MarketlineVO> GenerateMaketlines()
        {
            var teamNamesIndex = 0;
            return Enumerable.Range(1, TeamNames.Length / 2).Select(index =>
                new MarketlineVO(TeamNames[teamNamesIndex++], TeamNames[teamNamesIndex++], GenerateOdds()));
        }
            
    }
}