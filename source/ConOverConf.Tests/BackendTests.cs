using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using ConOverConf.Contracts;
using ConOverConf.Contracts.Commands;
using NUnit.Framework;

namespace ConOverConf.Tests
{
    [TestFixture]
    public class BackendTests
    {
        [Test]
        public void Can_send_command_to_backend_service_host()
        {
            //var binding = new NetTcpBinding();
            
            //var address = new EndpointAddress("net.tcp://localhost:8731/Backend");

            //var backend = new ChannelFactory<IBackend>(binding, address).CreateChannel();
            //backend.SendCommand(new AddEmployeeToStoreCommand()
            //                        {
            //                            EmployeeId = Guid.NewGuid(),
            //                            StoreId =  Guid.NewGuid()
            //                        });
        }
    }
}