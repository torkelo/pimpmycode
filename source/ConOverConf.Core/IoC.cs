using System;
using ConOverConf.Core;

namespace ConOverConf.Handlers
{
    public static class IoC
    {
        public static IServiceLocator Container { get; set; }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static object Resolve(Type type)
        {
            return Container.Resolve(type);
        }
    }
}