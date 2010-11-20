namespace GameLibrary.Framework
{
    using System;

    public class ShowScreenResult<T> : IResult
        where T : IScreen
    {
        private Action<T> _configruation;

        public ShowScreenResult<T> Configured(Action<T> configuration)
        {
            _configruation = configuration;
            return this;
        }

        public void Execute()
        {
            var shell = IoC.GetInstance<IShell>();
            var screen = IoC.GetInstance<T>();

            if (_configruation != null)
                _configruation(screen);

            shell.OpenScreen(screen);

            Completed(this, EventArgs.Empty);
        }

        public event EventHandler Completed = delegate { };
    }
}