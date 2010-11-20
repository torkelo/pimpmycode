using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using ConOverConf.Contracts;
using ConOverConf.Handlers;

namespace ConOverConf.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //UnityBootstrapper.Setup();
            StructureMapBootstrapper.Setup();

            var host = new ServiceHost(typeof(Backend));  // this line takes 3-4 minutes

            host.AddServiceEndpoint(typeof(IBackend), new NetTcpBinding(), "net.tcp://localhost:8731/Backend");
            host.Open();


            Console.Read();
        }
    }
}
