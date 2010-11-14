using ConOverConf.Contracts;
using ConOverConf.Contracts.Commands;

namespace ConOverConf.Handlers
{
    public interface ICommandHandler<T> where T : Command
    {
        void Handle(T command);
    }
}