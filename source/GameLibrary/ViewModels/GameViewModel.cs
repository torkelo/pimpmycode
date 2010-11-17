using System;
using ConOverConf.Contracts.Data;
using GameLibrary.Framework;

namespace GameLibrary.ViewModels
{
    public class GameViewModel : ViewModelBase
    {
        private readonly GameDTO _gameDto;

        public GameViewModel(GameDTO gameDto)
        {
            _gameDto = gameDto;
        }

        public Guid Id { get { return _gameDto.Id;  } }

        public string Title { get { return _gameDto.Title;  } }

        public double Rating { get { return _gameDto.Rating;  } }

        public string Notes { get { return _gameDto.Notes;  } }

        public string Borrower { get { return _gameDto.Borrower; } set { _gameDto.Borrower = value; } }

        public DateTime AddedOn { get { return _gameDto.AddedOn; } }
    }
}