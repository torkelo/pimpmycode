using System.ServiceModel;
using ConOverConf.Contracts.Commands;
using ConOverConf.Contracts.Queries;

namespace ConOverConf.Contracts
{
    [ServiceContract]
    public interface IBackend
    {
        [OperationContract]
        void SendCommand(Command command);

        [OperationContract]
        QueryResult SendQuery(Query query);
    }
}