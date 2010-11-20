using System;
using ConOverConf.Core.Models;
using ConOverConf.Core.Services;

namespace ConOverConf.Persistence.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public void Save(Store store)
        {
            NHSessionFactory.GetCurrent().Save(store);
        }

        public Store GetBy(Guid id)
        {
            return NHSessionFactory.GetCurrent().Get<Store>(id);
        }
    }
}