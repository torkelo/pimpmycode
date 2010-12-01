using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ConOverConf.Contracts.Commands;

namespace ConOverConf.Contracts
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public class Command
    { 
        public static IEnumerable<Type> GetKnownTypes()
        {
            return KnownTypesHelper.GetKnownTypes<Command>();
        }
    }
}