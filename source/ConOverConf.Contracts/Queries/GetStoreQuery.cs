using System;
using System.Runtime.Serialization;
using ConOverConf.Contracts.Data;

namespace ConOverConf.Contracts.Queries
{
    [DataContract]
    public class GetStoreQuery : Query<QueryResult>
    {
        [DataMember]
        public Guid StoreId { get; set; }
    }

    [DataContract]
    public class GetStoreQueryResult : QueryResult
    {
        [DataMember]
        public StoreDTO Store { get; set; }  
    }
}