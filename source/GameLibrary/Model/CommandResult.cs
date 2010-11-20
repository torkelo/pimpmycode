using ConOverConf.Contracts;

namespace GameLibrary.Model
{
    using System;
    using Framework;

    public class CommandResult : IResult
    {
        private readonly Command _command;

        public CommandResult(Command command)
        {
            _command = command;
        }

        public void Execute()
        {
            var bus = IoC.GetInstance<IBackendClient>();
            bus.Send(_command);
            Completed(this, EventArgs.Empty);
        }

        public event EventHandler Completed = delegate { };
    }
}