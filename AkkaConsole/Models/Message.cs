namespace AkkaConsole.Models
{
    public class Message
    {
        public string? Data { get; set; }

        public override string ToString()
        {
            return Data ?? "";
        }
    }
}
