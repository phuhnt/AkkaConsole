using Akka.Actor;
using API.Interfaces;

namespace API.Services
{
    public class PersistenceService : IPersistenceService
    {
        public IActorRef Actor { get; set; }
    }
}
