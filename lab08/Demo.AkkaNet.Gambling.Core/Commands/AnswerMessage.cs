namespace Demo.AkkaNet.Gambling.Core.Commands
{
    public class AnswerMessage
    {
        public AnswerMessage(double value)
        {
            Value = value;
        }

        public double Value;
    }
}