using ConOverConf.Contracts;
using ConOverConf.Contracts.Queries;

namespace ConOverConf.Handlers
{
    public class QueryInvoker : IQueryInvoker
    {
        public QueryResult Invoke(Query query)
        {   
            var handlerType = (typeof(IQueryHandler<>)).MakeGenericType(query.GetType());

            var handler = IoC.Resolve(handlerType);

            var result = (QueryResult)handler.GetType().GetMethod("Handle").Invoke(handler, new[] { query });
         
            return result;
        }
    }
}