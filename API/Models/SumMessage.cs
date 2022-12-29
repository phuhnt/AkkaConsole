namespace AkkaConsole.Models
{
    public class SumMessage
    {
        public RequestMessage RequestMessage { get; set; } = new RequestMessage();
        public List<int> NumsData { get; set; } = new List<int> { };

        public override string ToString()
        {
            return RequestMessage?.ToString() ?? "";
        }
    }
}
