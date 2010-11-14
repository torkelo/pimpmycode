using ConOverConf.Contracts.Queries;

namespace ConOverConf.Handlers
{
    public interface IQueryInvoker
    {
        QueryResult Invoke(Query command);
    }
}