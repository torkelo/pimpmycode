using ConOverConf.Contracts;

namespace ConOverConf.Handlers
{
    public interface IHandleQuery<T> 
    {
        object Handle(T query);
    }
}