using System;
using Akka.Actor;

namespace Demo.AkkaNet.MessageDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            ActorSystem system = ActorSystem.Create("my-first-akka");

            IActorRef emailSender = system.ActorOf<EmailSenderActor>("emailSender");

            EmailMessage emailMessage = new EmailMessage("from@mail.com", "to@mail.com", "Hi");

            emailSender.Tell(emailMessage);
            
            // Incorrect way to stop
            system.Stop(emailSender);
            
            // Suggest way to stop
//            var result = emailSender.GracefulStop(TimeSpan.FromSeconds(10));
//            Console.WriteLine($"GracefulStop return is {result.Result.ToString()}");
            
            system.Terminate();
            
            Console.WriteLine("Actor System terminated");

        }
    }
}