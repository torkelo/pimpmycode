using System;
using ConOverConf.Core;
using Microsoft.Practices.Unity;

namespace ConOverConf.ConsoleHost
{
    public class UnityServiceLocator : IServiceLocator
    {
        private readonly IUnityContainer _container;

        public UnityServiceLocator(IUnityContainer container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _container.Resolve(type);
        }
    }
}