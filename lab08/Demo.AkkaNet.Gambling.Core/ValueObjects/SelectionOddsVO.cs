namespace Demo.AkkaNet.Gambling.Core.ValueObjects
{
    public class SelectionOddsVO
    {
        public decimal[] Odds { get;}
        public string SelectionType { get; }

        public SelectionOddsVO(string type, decimal oddsA, decimal oddsB)
        {
            this.SelectionType = type;
            this.Odds = new[] {oddsA, oddsB};
        }
    }
}