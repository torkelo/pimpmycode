using System;
using ConOverConf.Contracts.Commands;

namespace ConOverConf.Handlers.CommandHandlers
{
    public class AddEmployeeToStoreCommandHandler : ICommandHandler<AddEmployeeToStoreCommand>
    {
        public void Handle(AddEmployeeToStoreCommand command)
        {
            Console.WriteLine("Command Handled: " + command.GetType().Name);
        }
    }
}