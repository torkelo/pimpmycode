using System;
using ConOverConf.Core.Models;

namespace ConOverConf.Core.Services
{
    public interface IEmployeeRepository
    {
        void Save(Employee store);
        Employee GetBy(Guid id);
    }
}