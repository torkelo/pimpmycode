namespace GameLibrary.Framework
{
    using System;
    using System.Windows;

    public static class Execute
    {
        private static Action<Action> _executor = action => action();

        public static void InitializeWithDispatcher()
        {
            var dispatcher = Deployment.Current.Dispatcher;

            _executor = action => {
                if (dispatcher.CheckAccess())
                    action();
                else dispatcher.BeginInvoke(action);
            };
        }

        public static void OnUIThread(this Action action)
        {
            _executor(action);
        }
    }
}