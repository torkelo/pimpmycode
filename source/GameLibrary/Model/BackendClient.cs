using System.ServiceModel;
using System.ServiceModel.Channels;
using ConOverConf.Contracts;
using ConOverConf.Contracts.Data;

namespace GameLibrary.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Reflection;
    using System.Threading;

    [Export(typeof(IBackendClient))]
    public class BackendClient : IBackendClient
    {
        public void Send<TResponse>(Query<TResponse> query, Action<TResponse> reply) where TResponse : QueryResult
        {
            var channel = GetBackendChannel();
            channel.BeginSendQuery(query, result => reply((TResponse)channel.EndSendQuery(result)), null);
        }

        public void Send(Command command)
        {
            var channel = GetBackendChannel();
            channel.BeginSendCommand(command, result => { }, null);
        }

        private IBackend GetBackendChannel()
        {
            //var messageEncoding = new BinaryMessageEncodingBindingElement();
            //var tcpTransport = new TcpTransportBindingElement();
            //var binding = new CustomBinding(messageEncoding, tcpTransport);
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);

            var address = new EndpointAddress("http://localhost:8731/Backend");
            return new ChannelFactory<IBackend>(binding, address).CreateChannel();
        }
    }
}