using Akka.Actor;
using API.Interfaces;

namespace API.Services
{
    public class CalculationService : ICalculationService
    {
        public IActorRef Actor { get; set; }
    }
}
