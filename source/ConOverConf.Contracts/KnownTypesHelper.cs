using System;
using System.Collections.Generic;
using System.Linq;

namespace ConOverConf.Contracts
{
    static class KnownTypesHelper
    {
        public static IEnumerable<Type> GetKnownTypes<T>()
        {
            var list = new List<Type>();
            var queryTypes = typeof(T).Assembly.GetExportedTypes()
                .Where(x => typeof(T).IsAssignableFrom(x) && !x.IsGenericTypeDefinition);

            list.AddRange(queryTypes);
            return list;
        }
    }
}