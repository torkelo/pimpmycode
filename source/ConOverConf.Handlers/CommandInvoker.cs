using System;
using System.Transactions;
using ConOverConf.Contracts;
using ConOverConf.Contracts.Commands;
using ConOverConf.Handlers.CommandHandlers;

namespace ConOverConf.Handlers
{
    public class CommandInvoker : ICommandInvoker
    {
        public void Invoke(Command command)
        {
            Console.WriteLine("Command Received: {0}", command.GetType().Name);

            var handlerType = GetHandlerTypeFor(command);
            
            var handler = IoC.Resolve(handlerType);
            
            using (var scope = new TransactionScope())
            {
                handler.GetType().GetMethod("Handle").Invoke(handler, new object[] { command });
                scope.Complete();
            }
        }

        public Type GetHandlerTypeFor(Command command)
        {
            var typeHandler = typeof (IHandleCommand<>).MakeGenericType(command.GetType());
            return typeHandler;
        }
    }
}