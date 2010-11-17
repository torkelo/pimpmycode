using System;
using System.Collections.Generic;
using AutoMapper;
using ConOverConf.Contracts;
using ConOverConf.Contracts.Data;
using ConOverConf.Contracts.Queries;
using ConOverConf.Core.Models;
using ConOverConf.Core.Services;

namespace ConOverConf.Handlers.QueryHandlers
{
    public class SearchGamesHandler : IHandleQuery<SearchGames>
    {
        private readonly IGameRepository _gameRepository;

        public SearchGamesHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public object Handle(SearchGames query)
        {
            var games = _gameRepository.Search(query.SearchText);
            
            var result = new SearchGamesResult();
            result.Hits = Mapper.Map<IEnumerable<Game>, IEnumerable<SearchResultDTO>>(games);

            return result;
        }
    }
}