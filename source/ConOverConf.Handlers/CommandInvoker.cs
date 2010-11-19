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

            var handlerType = (typeof (IHandleCommand<>)).MakeGenericType(command.GetType());
            
            var handler = IoC.Resolve(handlerType);
            
            using (var scope = new TransactionScope())
            {
                handler.GetType().GetMethod("Handle").Invoke(handler, new object[] { command });
                scope.Complete();
            }
        }

        public void ConfigurationExample(Command command)
        {
            if (command is AddGameToLibrary)
            {
                IoC.Resolve<AddGameToLibraryHandler>().Handle((AddGameToLibrary)command);
            }

            if (command is CheckGameIn)
            {
                IoC.Resolve<CheckGameInHandler>().Handle((CheckGameIn)command);
            }

            if (command is CheckGameOut)
            {
                IoC.Resolve<CheckGameOutHandler>().Handle((CheckGameOut)command);
            }
        }
    }
}