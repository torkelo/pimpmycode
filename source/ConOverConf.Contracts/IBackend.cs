namespace ConOverConf.Contracts
{
    public interface IBackend
    {
        void SendCommand(ICommand command);
        IQueryResult SendQuery(IQuery query);
    }
}