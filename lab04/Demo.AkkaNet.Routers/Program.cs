using System;
using Akka.Actor;

namespace Demo.AkkaNet.Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application Start...");

            ActorSystem system = ActorSystem.Create("My-Akka-Routing-Calculator");

            var calculatorWithRoundRobinPool =
                system.ActorOf(Props.Create<CalculatorActor>().WithRouter(new Akka.Routing.RoundRobinPool(4)),
                    "RoundRobinPool");
            var calculatorWithRandomPool =
                system.ActorOf(Props.Create<CalculatorActor>().WithRouter(new Akka.Routing.RandomPool(4)),
                    "RandomPool");
            var calculatorWithSmallestMailboxPool =
                system.ActorOf(Props.Create<CalculatorActor>().WithRouter(new Akka.Routing.SmallestMailboxPool(4)),
                    "SmallestMailboxPool");
            var calculatorWithConsistentHashingPool =
                system.ActorOf(Props.Create<CalculatorActor>().WithRouter(
                        new Akka.Routing.ConsistentHashingPool(4).WithHashMapping(x =>
                        {
                            if (x is Add)
                            {
                                return ((Add) x).Term1;
                            }

                            return x;
                        })),
                    "ConsistentHashingPool");
            var calculatorWithBroadcastPool =
                system.ActorOf(Props.Create<CalculatorActor>().WithRouter(new Akka.Routing.BroadcastPool(4)),
                    "BroadcastPool");

            Test(calculatorWithRoundRobinPool);
            Test(calculatorWithRandomPool);
            Test(calculatorWithSmallestMailboxPool);
            Test(calculatorWithConsistentHashingPool);
            Test(calculatorWithBroadcastPool);

            Console.Read();
            system.Terminate();
        }

        private static void Test(IActorRef calculatorRef)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(calculatorRef.Path.Name);

            Console.ForegroundColor = ConsoleColor.Gray;
            var result1 = calculatorRef.Ask(new Add(10, 20)).Result as Answer;
            var result2 = calculatorRef.Ask(new Add(11, 30)).Result as Answer;
            var result3 = calculatorRef.Ask(new Add(12, 40)).Result as Answer;
            var result4 = calculatorRef.Ask(new Add(13, 10)).Result as Answer;
            var result5 = calculatorRef.Ask(new Add(14, 25)).Result as Answer;

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"Result 1 : {result1.Value}");
            Console.WriteLine($"Result 2 : {result2.Value}");
            Console.WriteLine($"Result 3 : {result3.Value}");
            Console.WriteLine($"Result 4 : {result4.Value}");
            Console.WriteLine($"Result 5 : {result5.Value}");
            Console.WriteLine();
        }
    }
}