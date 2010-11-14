using ConOverConf.Contracts.Commands;

namespace ConOverConf.Handlers
{
    public interface ICommandInvoker
    {
        void Invoke(Command command);
    }
}