namespace AkkaConsole.Models
{
    public class PersistenceMessage
    {
        public RequestMessage RequestMessage { get; set; } = new RequestMessage();
        public int Result { get; set; }

        public override string ToString()
        {
            return RequestMessage.ToString() + " - Result: " + Result.ToString();
        }
    }
}
