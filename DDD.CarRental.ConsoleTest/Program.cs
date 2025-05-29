using DDD.CarRental.Core.ApplicationLayer.Commands.Handlers;
using DDD.CarRental.Core.ApplicationLayer.Mappers;
using DDD.CarRental.Core.ApplicationLayer.Queries.Handlers;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.InfrastructureLayer.EF;
using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.InfrastructureLayer.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using DDD.CarRental.Core.DomainModelLayer.Events;
using DDD.CarRental.Core.DomainModelLayer.Services;
using DDD.CarRental.Core.InfrastructureLayer.DomainEventHandlers;
using DDD.SharedKernel.ApplicationLayer;

namespace DDD.CarRental.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // create and configure DI container
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create TestSuit & run scenario test
            var testSuit = new TestSuit(serviceCollection);
            testSuit.Run();
        }

        static private void ConfigureServices(IServiceCollection serviceCollection)
        {
            // intializing and registering CarRentalDbContext
            var context = TestUtils.InitializeCarRentalContext();
            serviceCollection.AddSingleton(context);
            serviceCollection.AddSingleton<IMaintenanceRepository, MaintenanceRepository>();

            serviceCollection.AddSingleton<IPositionService, PositionService>();

            // registering command and query handlers
            serviceCollection.AddSingleton<CommandHandler>();
            serviceCollection.AddSingleton<QueryHandler>();

            // registering event publisher and handlers
            serviceCollection.AddSingleton<IDomainEventPublisher, SimpleEventPublisher>();
            serviceCollection.AddSingleton<IEventHandler<CarTakenDomainEvent>, CarTakenEventHandler>();
            
            // registering unit of work and repos
            serviceCollection.AddSingleton<ICarRentalUnitOfWork, CarRentalUnitOfWork>();
            serviceCollection.AddSingleton<ICarRepository, CarRepository>();
            serviceCollection.AddSingleton<IDriverRepository, DriverRepository>();
            serviceCollection.AddSingleton<IRentalRepository, RentalRepository>();
            
            // registering domain model services, factories
            //Nie dodajemy mappera bo jest u nas klasą typu static zamiast servicem singleton 
            //serviceCollection.AddSingleton<Mapper>();

            // ToDo: Zarejestruj pozostałe usługi, fabryki, polityki, itp.
        }
    }
}
