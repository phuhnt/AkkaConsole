using Akka.Actor;
using AkkaConsole.Models;
using API.Interfaces;
using System.Text.RegularExpressions;

namespace AkkaConsole.Actors
{
    internal class CheckingActor : ReceiveActor
    {
        private readonly ICalculationService _calculationActor;

        public CheckingActor(ICalculationService calculationActor)
        {
            _calculationActor = calculationActor;

            Receive<RequestMessage>((message) =>
            {
                Console.WriteLine("\n>>> [{0}] receive message: [{1}]", Self.Path, message.ToString());
                HandleMessage(message);
            });
        }


        protected override void PreStart()
        {
            // Console.WriteLine("[{0}]: PreStart", Self.Path);
            base.PreStart();
        }

        protected override void PostStop()
        {
            // Console.WriteLine("[{0}]: PostStop", Self.Path);
            base.PostStop();
        }

        private void HandleMessage(RequestMessage message)
        {
            List<int> numbersOnly = Regex.Replace(message.Data, @"[^\d]", String.Empty)
                                    .ToCharArray()
                                    .ToList()
                                    .Select(item => int.Parse(item.ToString()))
                                    .ToList();

            var res = _calculationActor.Actor.Ask(new SumMessage { RequestMessage = message, NumsData = numbersOnly });

            Sender.Tell(res);
        }
    }
}
