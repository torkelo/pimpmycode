using System.ServiceModel;

namespace ConOverConf.Contracts
{
    [ServiceContract]
    public interface IBackend
    {
        [OperationContract]
        void SendCommand(Command command);

        [OperationContract]
        object SendQuery(Query query);
    }
}