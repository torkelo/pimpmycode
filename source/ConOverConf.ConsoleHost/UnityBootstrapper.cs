using System.Linq;
using ConOverConf.Handlers;
using ConOverConf.Handlers.CommandHandlers;
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
            
            //container.RegisterType<IHandleCommand<OpenStoreCommand>, OpenStoreCommandHandler>();
            //container.RegisterType<IHandleCommand<AddEmployeeToStoreCommand>, AddEmployeeToStoreCommandHandler>();

            //container.RegisterType<IHandleQuery<GetStoreQuery>, GetStoreQueryHandler>();
            RegisterCommandsAndQueryHandlersByConvention(container);

            // container.RegisterType<IStoreRepository, StoreRepository>();
            // container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            RegisterRepositoriesByConvention(container);

            IoC.Container = new UnityServiceLocator(container);
        }

        public static void RegisterCommandsAndQueryHandlersByConvention(IUnityContainer container)
        {
            var typesInAssembly = typeof (AddGameToLibraryHandler).Assembly.GetExportedTypes();
            //foreach (var type in typesInAssembly)
            //{
            //    foreach (var interfaceType in type.GetInterfaces())
            //    {
            //        if (!interfaceType.IsGenericType)
            //            continue;
                    
            //        if (interfaceType.GetGenericTypeDefinition() == typeof(IHandleCommand<>))
            //        {
            //            container.RegisterType(interfaceType, type);
            //        }
            //    }
            //}

            foreach (var type in typesInAssembly
                .Where(x => x.Namespace.Contains("CommandHandlers") || x.Namespace.Contains("QueryHandlers")))
            {
                container.RegisterType(type.GetInterfaces()[0], type);
            }
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