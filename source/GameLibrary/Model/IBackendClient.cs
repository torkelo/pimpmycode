using ConOverConf.Contracts;

namespace GameLibrary.Model
{
    using System;

    public interface IBackendClient
    {
        void Send(Command command);
        void Send<TResponse>(Query<TResponse> query, Action<TResponse> reply) where TResponse : QueryResult;
    }
}