
using AutoMapper;
using ConOverConf.Contracts;
using ConOverConf.Contracts.Data;
using ConOverConf.Contracts.Queries;
using ConOverConf.Core.Models;
using ConOverConf.Core.Services;

namespace ConOverConf.Handlers.QueryHandlers
{
    public class GetGameHandler : IHandleQuery<GetGame>
    {
        private readonly IGameRepository _repository;

        public GetGameHandler(IGameRepository repository)
        {
            _repository = repository;
        }

        public QueryResult Handle(GetGame query)
        {
            var game = _repository.GetBy(query.Id);

            return Mapper.Map<Game, GameDTO>(game);
        }
    }
}