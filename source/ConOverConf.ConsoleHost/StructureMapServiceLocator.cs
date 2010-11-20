using System;
using ConOverConf.Core;
using StructureMap;

namespace ConOverConf.ConsoleHost
{
    public class StructureMapServiceLocator : IServiceLocator
    {
        private readonly Container _container;

        public StructureMapServiceLocator(Container container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return _container.GetInstance<T>();
        }

        public object Resolve(Type type)
        {
            return _container.GetInstance(type);
        }
    }
}