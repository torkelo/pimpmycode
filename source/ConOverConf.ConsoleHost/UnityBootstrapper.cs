using System.Linq;
using ConOverConf.Contracts.Commands;
using ConOverConf.Contracts.Queries;
using ConOverConf.Core.Services;
using ConOverConf.Handlers;
using ConOverConf.Handlers.CommandHandlers;
using ConOverConf.Handlers.QueryHandlers;
using ConOverConf.Persistence.Repositories;
using Microsoft.Practices.Unity;

namespace ConOverConf.ConsoleHost
{
    public static class UnityBootstrapper
    {
        public static void Setup()
        {
            var container = new UnityContainer();
            
            container.RegisterType<ICommandInvoker, CommandInvoker>();
            container.RegisterType<IQueryInvoker, QueryInvoker>();

            container.RegisterType<IHandleCommand<AddGameToLibrary>, AddGameToLibraryHandler>();
            container.RegisterType<IHandleCommand<CheckGameIn>, CheckGameInHandler>();
            container.RegisterType<IHandleCommand<CheckGameOut>, CheckGameOutHandler>();

            container.RegisterType<IHandleQuery<SearchGames>, SearchGamesHandler>();
            container.RegisterType<IHandleQuery<GetGame>, GetGameHandler>();
            
            //RegisterCommandsAndQueryHandlersByConvention(container);

            container.RegisterType<IStoreRepository, StoreRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IGameRepository, GameRepository>();
            
            //RegisterRepositoriesByConvention(container);

            IoC.Container = new UnityServiceLocator(container);
        }

        public static void RegisterCommandsAndQueryHandlersByConvention(IUnityContainer container)
        {
            var typesInAssembly = typeof (AddGameToLibraryHandler).Assembly.GetExportedTypes();

            
        }

        public static void RegisterRepositoriesByConvention(IUnityContainer container)
        {
            var typesInAssembly = typeof(StoreRepository).Assembly.GetExportedTypes();
            foreach (var type in typesInAssembly
                .Where(x => x.Namespace.Contains("Repositories")))
            {
                container.RegisterType(type.GetInterfaces()[0], type);
            }
        }
    }
}