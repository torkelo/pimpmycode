using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public class QueryResult
    {
        public static IEnumerable<Type> GetKnownTypes()
        {
            return KnownTypesHelper.GetKnownTypes<QueryResult>();
        }
    }
}