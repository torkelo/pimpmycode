using System;

namespace ConOverConf.Contracts.Commands
{
    public class AddEmployeeToStoreCommand : ICommand
    {
        public Guid StoreId { get; set; }

        public Guid EmployeeId { get; set; }
    }
}