using System;
using ConOverConf.Core.Models;
using ConOverConf.Core.Services;

namespace ConOverConf.Persistence.Repositories
{
    public class EmployeeRepository : IEmployeeRepository  
    {
        public void Save(Employee store)
        {
            NHSessionFactory.GetCurrent().Save(store);
        }

        public Employee GetBy(Guid id)
        {
            return NHSessionFactory.GetCurrent().Get<Employee>(id);
        }
    }
}