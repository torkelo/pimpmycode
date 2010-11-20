using System;
using ConOverConf.Contracts;
using ConOverConf.Contracts.Queries;

namespace ConOverConf.Handlers.QueryHandlers
{
    public class GetGameHandler : IHandleQuery<GetGame>
    {
        public object Handle(GetGame query)
        {
            return null;
        }
    }
}