using Akka.Actor;

namespace API.Interfaces
{
    public interface ICheckingService
    {
        public IActorRef Actor { get; }
    }
}
