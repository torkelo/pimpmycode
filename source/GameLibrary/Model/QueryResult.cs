using ConOverConf.Contracts;

namespace GameLibrary.Model
{
    using System;
    using Framework;

    public class QueryResult<TResponse> : IResult where TResponse : QueryResult
    {
        private readonly Query<TResponse> _query;

        public TResponse Response { get; set; }

        public QueryResult(Query<TResponse> query)
        {
            _query = query;
        }

        public void Execute()
        {
            IoC.GetInstance<IBackendClient>().Send(_query, response => {
                Response = response;
                Framework.Execute.OnUIThread(() => Completed(this, EventArgs.Empty));
            });
        }

        public event EventHandler Completed = delegate { };
    }
}