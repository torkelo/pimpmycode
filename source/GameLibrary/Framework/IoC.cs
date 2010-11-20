namespace GameLibrary.Framework
{
    using System.ComponentModel.Composition.Hosting;
    using System.Reflection;

    public static class IoC
    {
        private static CompositionContainer _compositionContainer;

        public static void InitializeWithMef()
        {
            _compositionContainer = CompositionHost.Initialize(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        }

        public static T GetInstance<T>()
        {
            return _compositionContainer.GetExportedValue<T>();
        }
    }
}