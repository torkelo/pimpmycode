using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public class Query
    {
        public static IEnumerable<Type> GetKnownTypes()
        {
            return KnownTypesHelper.GetKnownTypes<Query>();
        }
    }

    [DataContract]
    public class Query<T> : Query
    {

    }
}