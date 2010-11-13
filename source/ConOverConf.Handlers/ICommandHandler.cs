using ConOverConf.Contracts;

namespace ConOverConf.Handlers
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}