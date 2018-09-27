namespace Demo.AkkaNet.HelloWorld.Messages
{
    public class GreetingMessage
    {
        public GreetingMessage(string greeting)
        {
            Greeting = greeting;
        }

        public string Greeting { get; }
    }
}