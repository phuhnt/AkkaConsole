using Akka.Actor;
using API.Interfaces;

namespace API.Services
{
    public class CheckingService : ICheckingService
    {
        public IActorRef Actor { get; set; }
    }
}
