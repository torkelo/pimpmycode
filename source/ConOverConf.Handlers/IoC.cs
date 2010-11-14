using System;
using Microsoft.Practices.ServiceLocation;

namespace ConOverConf.Handlers
{
    public static class IoC
    {
        public static IServiceLocator Container { get; set; }

        public static T Resolve<T>()
        {
            return Container.GetInstance<T>();
        }

        public static object Resolve(Type type)
        {
            return Container.GetInstance(type);
        }
    }
}