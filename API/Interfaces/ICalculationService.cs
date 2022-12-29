using Akka.Actor;

namespace API.Interfaces
{
    public interface ICalculationService
    {
        public IActorRef Actor { get; }
    }
}
