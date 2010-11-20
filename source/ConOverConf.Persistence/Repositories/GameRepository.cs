using System;
using System.Collections.Generic;
using ConOverConf.Core.Models;
using ConOverConf.Core.Services;
using NHibernate.Criterion;
using NHibernate.Linq;

namespace ConOverConf.Persistence.Repositories
{
    public class GameRepository : IGameRepository
    {
        public void Save(Game game)
        {
            NHSessionFactory.GetCurrent().Save(game);
        }

        public Game GetBy(Guid id)
        {
            return NHSessionFactory.GetCurrent().Get<Game>(id);
        }

        public IEnumerable<Game> Search(string searchText)
        {
            return NHSessionFactory.GetCurrent()
                .CreateCriteria<Game>()
                    .Add(Restrictions.Like("Title", "%" + searchText + "%"))
                    .List<Game>();
        }
    }
}