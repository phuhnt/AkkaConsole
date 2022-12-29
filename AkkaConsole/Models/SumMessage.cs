namespace AkkaConsole.Models
{
    public class SumMessage
    {
        public List<int>? Data { get; set; }

        public override string ToString()
        {
            return Data?.ToString() ?? "";
        }
    }
}
