namespace Demo.AkkaNet.Gambling.Core.ValueObjects
{
    public class MarketlineVO
    {
        public string[] TeamNames { get; }
        public SelectionOddsVO SpreadSelectionOdds { get; }
        public SelectionOddsVO TotalSelectionOdds { get; }
        public SelectionOddsVO MoneylineSelectionOdds { get; set; }

        public MarketlineVO(string teamNameA, string teamNameB, decimal[][] odds)
        {
            this.TeamNames = new[] {teamNameA, teamNameB};
            this.SpreadSelectionOdds = new SelectionOddsVO("Spread",odds[0][0],odds[0][1]);
            this.TotalSelectionOdds = new SelectionOddsVO("Total",odds[1][0],odds[1][1]);
            this.MoneylineSelectionOdds = new SelectionOddsVO("Moneyline",odds[2][0],odds[2][1]);
        }
    }
}