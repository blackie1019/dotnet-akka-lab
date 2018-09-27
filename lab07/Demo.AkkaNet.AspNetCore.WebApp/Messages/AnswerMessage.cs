namespace Demo.AkkaNet.AspNetCore.WebApp.Messages
{
    public class AnswerMessage
    {
        public AnswerMessage(double value) {
            Value = value;
        }
        public double Value { get; }
    }
}