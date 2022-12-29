using Akka.Actor;
using AkkaConsole.Models;

namespace AkkaConsole.Actors
{
    public class SumActor : ReceiveActor
    {
        public SumActor()
        {
            //Console.WriteLine("Sum acttor: initialized");
            Receive<SumMessage>((message) =>
            {
                HandleMessage(message);
            });
        }


        protected override void PreStart()
        {
            //Console.WriteLine("Sum acttor: PreStart");
            base.PreStart();
        }

        protected override void PostStop()
        {
            //Console.WriteLine("Sum acttor: PostStop");
            base.PostStop();
        }

        private void HandleMessage(SumMessage sumMessage)
        {
            if (sumMessage == null || sumMessage.Data == null)
            {
                Console.WriteLine(">>>Sum actor: Invalid input");
                return;
            }

            var sum = sumMessage.Data.Sum();
            Sender.Tell(sum);
        }
    }
}
