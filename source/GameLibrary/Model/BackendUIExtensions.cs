using ConOverConf.Contracts;

namespace GameLibrary.Model
{
    public static class BackendUIExtensions
    {
        public static QueryResult<TResponse> AsResult<TResponse>(this Query<TResponse> query)
        {
            return new QueryResult<TResponse>(query);
        }

        public static CommandResult AsResult(this Command command)
        {
            return new CommandResult(command);
        }
    }
}