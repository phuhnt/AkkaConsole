using Akka.Actor;
using AkkaConsole.Models;
using System.Text.RegularExpressions;

namespace AkkaConsole.Actors
{
    internal class CheckingActor : ReceiveActor
    {
        public CheckingActor()
        {
            // Console.WriteLine("Checking acttor: initialized");
            Receive<Message>((message) =>
            {
                Console.WriteLine("\n>>> [{0}] receive message: [{1}]", Self.Path, message.ToString());
                HandleMessage(message);
            });
        }


        protected override void PreStart()
        {
            // Console.WriteLine("Checking acttor: PreStart");
            base.PreStart();
        }

        protected override void PostStop()
        {
            // Console.WriteLine("Checking acttor: PostStop");
            base.PostStop();
        }

        private void HandleMessage(Message message)
        {
            if (message == null || string.IsNullOrEmpty(message.Data))
            {
                Console.WriteLine(">>> Checking acttor: Input invalid");
                return;
            }

            List<int> numbersOnly = Regex.Replace(message.Data, @"[^\d]", String.Empty)
                                    .ToCharArray()
                                    .ToList()
                                    .Select(item => int.Parse(item.ToString()))
                                    .ToList();

            var sumActor = Context.ActorOf<SumActor>();
            var response = sumActor.Ask(new SumMessage { Data = numbersOnly });

            Sender.Tell(response.Result);
        }
    }
}
