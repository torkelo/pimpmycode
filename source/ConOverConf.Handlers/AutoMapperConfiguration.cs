using AutoMapper;
using ConOverConf.Contracts.Commands;
using ConOverConf.Contracts.Data;
using ConOverConf.Core.Models;

namespace ConOverConf.Handlers
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Game, GameDTO>();
            Mapper.CreateMap<Game, SearchResultDTO>();
            
        }
    }
}