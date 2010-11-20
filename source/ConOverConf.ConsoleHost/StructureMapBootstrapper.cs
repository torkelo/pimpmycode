using System;
using ConOverConf.Handlers;
using ConOverConf.Handlers.CommandHandlers;
using ConOverConf.Handlers.QueryHandlers;
using ConOverConf.Persistence.Repositories;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace ConOverConf.ConsoleHost
{
    public static class StructureMapBootstrapper
    {
        public static void Setup()
        {
            var container = new Container(registry => 
            {
                registry.For<ICommandInvoker>().Add<CommandInvoker>();
                registry.For<IQueryInvoker>().Add<QueryInvoker>();

                registry.AddRegistry<CommandAndQueryHandlerRegistry>();
                registry.AddRegistry<RepositoryRegistry>();
            });

            IoC.Container = new StructureMapServiceLocator(container);
        }
    }

    public class CommandAndQueryHandlerRegistry : Registry
    {
        public CommandAndQueryHandlerRegistry()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<AddGameToLibraryHandler>();
                x.IncludeNamespaceContainingType<AddGameToLibraryHandler>();
                x.IncludeNamespaceContainingType<GetGameHandler>();

                x.ConnectImplementationsToTypesClosing(typeof(IHandleCommand<>));
                x.ConnectImplementationsToTypesClosing(typeof(IHandleQuery<>));
            });
        }
    }

    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            Scan(x =>
            {
                x.AssemblyContainingType<StoreRepository>();
                x.IncludeNamespaceContainingType<StoreRepository>();
                
                x.RegisterConcreteTypesAgainstTheFirstInterface();
            });
        }
    }

    public class CustomRegistrationConvetion : IRegistrationConvention
    {
        public void Process(Type type, Registry registry)
        {
            
        }
    }

    
}