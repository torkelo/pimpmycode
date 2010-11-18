using ConOverConf.Contracts;

namespace ConOverConf.Handlers
{
    public interface IHandleQuery<T> 
    {
        QueryResult Handle(T query);
    }
}