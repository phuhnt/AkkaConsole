using Akka.Actor;

namespace API.Interfaces
{
    public interface IPersistenceService
    {
        public IActorRef Actor { get; }
    }
}
