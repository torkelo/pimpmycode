namespace GameLibrary.Framework
{
    public static class Show
    {
        public static BusyResult Busy()
        {
            return new BusyResult(true);
        }

        public static BusyResult NotBusy()
        {
            return new BusyResult(false);
        }

        public static ShowScreenResult<T> Screen<T>()
            where T : IScreen
        {
            return new ShowScreenResult<T>();
        }
    }
}