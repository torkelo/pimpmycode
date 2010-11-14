using System;
using System.Runtime.Serialization;
using ConOverConf.Contracts.Data;

namespace ConOverConf.Contracts.Queries
{
    [DataContract]
    public class GetStoreQuery : Query<QueryResult>
    {
        [DataMember]
        public Guid ContractId { get; set; }
    }

    [DataContract]
    public class GetStoreQueryResult
    {
        [DataMember]
        public StoreDTO Contact { get; set; }  
    }
}