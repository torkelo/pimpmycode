using ConOverConf.Contracts;
using Microsoft.Practices.ServiceLocation;

namespace ConOverConf.Handlers
{
    public class Backend : IBackend
    {
        private readonly IServiceLocator serviceLocator;

        public Backend(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void SendCommand(ICommand command)
        {
            var handlerType = typeof (ICommandHandler<>).MakeGenericType(command.GetType());

            var commandHandler = serviceLocator.GetInstance(handlerType);

            handlerType.GetMethod("Handle").Invoke(commandHandler, new[] { command });
        }

        public IQueryResult SendQuery(IQuery query)
        {
            var handlerType = typeof(IQueryHandler<>).MakeGenericType(query.GetType());

            var queryHandle = serviceLocator.GetInstance(handlerType);

            return handlerType.GetMethod("Handle").Invoke(queryHandle, new[] { query }) as IQueryResult;
        }
    }
}