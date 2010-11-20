using System;
using AutoMapper;
using ConOverConf.Contracts.Commands;
using ConOverConf.Core.Models;
using ConOverConf.Core.Services;

namespace ConOverConf.Handlers.CommandHandlers
{
    public class AddGameToLibraryHandler : IHandleCommand<AddGameToLibrary>
    {
        private readonly IGameRepository _gameRepository;

        public AddGameToLibraryHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void Handle(AddGameToLibrary command)
        {
            var game = new Game(command.Title, command.Rating, command.Notes);
            _gameRepository.Save(game);
        }
    }
}