using Akka.Actor;
using AkkaConsole.Actors;
using AkkaConsole.Models;

namespace AkkaConsole
{
    static class Program
    {
        public const int NUM_OF_ACTTOR = 3;
        public static readonly ActorSystem actorSystem = ActorSystem.Create("akka-master-node");
        public static readonly Props props = Props.Create<CheckingActor>()
                        .WithRouter(new Akka.Routing.RoundRobinPool(NUM_OF_ACTTOR));
        public static readonly IActorRef actor = actorSystem.ActorOf(props, "actor");

        static void Main(string[] args)
        {
            string? input = args[0];
            while (input != "exit")
            {
                Console.WriteLine("-------------------------------------------");
                var res = actor.Ask(new Message { Data = input });
                Console.WriteLine(">>> Result: {0}", res.Result);
            }

            //while (input != "exit")
            //{
            //    Console.WriteLine("-------------------------------------------");
            //    Console.Write("\nPlease input param: ");
            //    input = Console.ReadLine();
            //    if (input != "exit")
            //    {
            //        var res = actorRef.Ask(new Message { Data = input });
            //        Console.WriteLine("Result: {0}", res.Result);
            //    }
            //};

            //Console.WriteLine("Program exit...");
            //Console.ReadKey();
        }
    }
}