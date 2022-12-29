using Akka.Actor;
using AkkaConsole.Actors;
using API.Interfaces;
using API.Services;

namespace API
{
    public class Program
    {
        public const int NUM_OF_CHECKING_ACTTOR = 3;
        public const int NUM_OF_CALCULATION_ACTTOR = 3;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            ActorSystem actorSystem = ActorSystem.Create("akka-master-node");

            // Persistence
            IActorRef persistenceActor = actorSystem.ActorOf<PersistenceActor>("persisenceActor");
            IPersistenceService persistenceService = new PersistenceService { Actor = persistenceActor };

            // Calculattion
            Props calculationProps = Props.Create<CalculationActor>(persistenceService)
                                                                    .WithRouter(new Akka.Routing.RoundRobinPool(NUM_OF_CALCULATION_ACTTOR));
            IActorRef calculationActor = actorSystem.ActorOf(calculationProps, "calculationActor");
            ICalculationService calculationService = new CalculationService { Actor = calculationActor };

            // Checking
            Props checkingProps = Props.Create<CheckingActor>(calculationService)
                                                                .WithRouter(new Akka.Routing.RoundRobinPool(NUM_OF_CHECKING_ACTTOR));
            IActorRef checkingActor = actorSystem.ActorOf(checkingProps, "checkingActor");
            ICheckingService checkingService = new CheckingService { Actor = checkingActor };

            builder.Services.AddSingleton(typeof(ICheckingService), checkingService);
            builder.Services.AddSingleton(typeof(ICalculationService), calculationService);
            builder.Services.AddSingleton(typeof(IPersistenceService), persistenceService);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}