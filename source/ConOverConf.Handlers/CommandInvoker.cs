using System;
using System.Transactions;
using ConOverConf.Contracts;
using ConOverConf.Contracts.Commands;

namespace ConOverConf.Handlers
{
    public class CommandInvoker : ICommandInvoker
    {
        public void Invoke(Command command)
        {
            Console.WriteLine("Command Received: {0}", command.GetType().Name);

            var handlerType = (typeof (IHandleCommand<>)).MakeGenericType(command.GetType());

            var handler = IoC.Resolve(handlerType);
            
            using (var scope = new TransactionScope())
            {
                handler.GetType().GetMethod("Handle").Invoke(handler, new object[] { command });
                scope.Complete();
            }
        }

        
    }
}