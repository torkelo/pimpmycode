using System;
using System.Collections.Generic;
using ConOverConf.Core.Models;

namespace ConOverConf.Core.Services
{
    public interface IGameRepository
    {
        void Save(Game game);
        Game GetBy(Guid id);
        
        IEnumerable<Game> Search(string searchText);
    }
}