using System.ServiceModel;
using ConOverConf.Contracts;
using ConOverConf.Contracts.Commands;
using ConOverConf.Contracts.Queries;

namespace ConOverConf.Handlers
{
    [ServiceBehavior(Name = "Backend",InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Single)]
    public class Backend : IBackend
    {
        public void SendCommand(Command command)
        {
            IoC.Resolve<ICommandInvoker>().Invoke(command);
        }

        public object SendQuery(Query query)
        {
            return IoC.Resolve<QueryInvoker>().Invoke(query);
        }
    }
}