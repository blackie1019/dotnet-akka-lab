namespace Demo.AkkaNet.HelloWorld.Messages
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