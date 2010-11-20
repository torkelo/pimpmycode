using System;

namespace ConOverConf.Core
{
    public interface IServiceLocator
    {
        T Resolve<T>();
        object Resolve(Type type);
    }
}