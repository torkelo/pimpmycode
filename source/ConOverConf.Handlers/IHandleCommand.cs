using ConOverConf.Contracts.Commands;
using ConOverConf.Contracts.Queries;

namespace ConOverConf.Handlers
{
    public interface IHandleCommand<T> where T : Command
    {
        void Handle(T command);
    }

    public interface IHandleQuery<T> 
    {
        QueryResult Handle(T query);
    }
}