using System;
using ConOverConf.Core.Models;

namespace ConOverConf.Core.Services
{
    public interface IStoreRepository
    {
        void Save(Store store);
        Store GetBy(Guid id);
    }
}