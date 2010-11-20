using System;
using System.ServiceModel;

namespace ConOverConf.Contracts
{
    [ServiceContract]
    public interface IBackend
    {
        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginSendCommand(Command command, AsyncCallback callback, object state);

        void EndSendCommand(IAsyncResult asyncResult);

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginSendQuery(Query query, AsyncCallback callback, object state);

        object EndSendQuery(IAsyncResult asyncResult);
    }
}   