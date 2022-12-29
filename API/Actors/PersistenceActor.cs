using Akka.Actor;
using AkkaConsole.Models;

namespace AkkaConsole.Actors
{
    internal class PersistenceActor : ReceiveActor
    {
        public PersistenceActor()
        {
            Receive<PersistenceMessage>((message) =>
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

        private void HandleMessage(PersistenceMessage message)
        {
            string res = DateTime.Now.ToString() + " " + message.ToString();
            Console.WriteLine(res);

            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Append text to an existing file named "WriteLines.txt".
            using (StreamWriter outputFile = File.AppendText(Path.Combine(docPath, "Persistence.txt").ToString()))
            {
                outputFile.WriteLine(res);
            }
        }
    }
}
