using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ConOverConf.Contracts.Commands
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