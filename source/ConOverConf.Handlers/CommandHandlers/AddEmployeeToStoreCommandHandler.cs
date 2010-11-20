using System;
using ConOverConf.Contracts.Commands;
using ConOverConf.Core.Services;

namespace ConOverConf.Handlers.CommandHandlers
{
    public class AddEmployeeToStoreCommandHandler : IHandleCommand<AddEmployeeToStoreCommand>
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeToStoreCommandHandler(IStoreRepository storeRepository, IEmployeeRepository employeeRepository)
        {
            _storeRepository = storeRepository;
            _employeeRepository = employeeRepository;
        }

        public void Handle(AddEmployeeToStoreCommand command)
        {
            var store = _storeRepository.GetBy(command.StoreId);
            var employee = _employeeRepository.GetBy(command.EmployeeId);

            store.AddEmployee(employee);
        }
    }
}