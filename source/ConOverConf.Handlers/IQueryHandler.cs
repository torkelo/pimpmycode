using ConOverConf.Contracts;
using ConOverConf.Contracts.Queries;

namespace ConOverConf.Handlers
{
    public interface IQueryHandler<T> where T : Query
    {
        void Handle(T query);
    }
}