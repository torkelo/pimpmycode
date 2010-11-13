using System;
using ConOverConf.Contracts.Data;

namespace ConOverConf.Contracts.Queries
{
    public class GetStoreQuery : IQuery
    {
        public Guid ContractId { get; set; }
    }

    public class GetStoreQueryResult
    {
        public StoreDTO Contact { get; set; }  
    }
}