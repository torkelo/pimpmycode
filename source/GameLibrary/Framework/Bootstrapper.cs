namespace GameLibrary.Framework
{
    using System.Windows;

    public static class Bootstrapper
    {
        public static UIElement CreateShell()
        {
            IoC.InitializeWithMef();
            Execute.InitializeWithDispatcher();

            var shell = IoC.GetInstance<IShell>();
            var view = ViewLocator.Locate(shell);

            ViewModelBinder.Bind(shell, view);

            return view;
        }
    }
}