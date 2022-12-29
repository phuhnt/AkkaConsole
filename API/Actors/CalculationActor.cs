using Akka.Actor;
using AkkaConsole.Models;
using API.Interfaces;

namespace AkkaConsole.Actors
{
    public class CalculationActor : ReceiveActor
    {
        private readonly IPersistenceService _persistenceActor;

        public CalculationActor(IPersistenceService persistenceActor)
        {
            _persistenceActor = persistenceActor;

            Receive<SumMessage>((message) =>
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

        private void HandleMessage(SumMessage sumMessage)
        {
            var sum = sumMessage.NumsData.Sum();
            Sender.Tell(sum);
            _persistenceActor.Actor.Tell(new PersistenceMessage { RequestMessage = sumMessage.RequestMessage, Result = sum });
        }
    }
}
