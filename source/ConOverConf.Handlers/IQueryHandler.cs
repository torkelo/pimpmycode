using ConOverConf.Contracts;

namespace ConOverConf.Handlers
{
    public interface IQueryHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}