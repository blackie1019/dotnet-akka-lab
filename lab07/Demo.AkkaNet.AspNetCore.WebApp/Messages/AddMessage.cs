namespace Demo.AkkaNet.AspNetCore.WebApp.Messages
{
    public class AddMessage
    {
        public AddMessage(double term1, double term2) {
            Term1 = term1;
            Term2 = term2;
        }
        public double Term1 { get; }
        public double Term2 { get; }
    }
}