using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Queries
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public class Query
    {
        [DataMember]
        public bool EnableStatistics { get; set; }

        public static IEnumerable<Type> GetKnownTypes()
        {
            return KnownTypesHelper.GetKnownTypes<Query>();
        }
    }

    [DataContract]
    public class Query<T> : Query where T : QueryResult
    {

    }
}