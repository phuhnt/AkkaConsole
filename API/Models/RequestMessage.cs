namespace AkkaConsole.Models
{
    public class BaseMessage
    {
        public string ReqUser { get; set; } = "";
    }

    public class RequestMessage : BaseMessage
    {
        public string? Data { get; set; }

        public override string ToString()
        {
            return string.Format("ReqUser: {0} - Data: {1}", ReqUser, Data);
        }
    }
}
