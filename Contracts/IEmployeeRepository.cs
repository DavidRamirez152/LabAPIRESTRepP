using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        Employee GetEmployee(Guid employeeId, bool trackChanges);
        IEnumerable<Employee> GetEmployeesCompany(Guid companyId, bool trackChanges);
        Employee GetEmployeeCompany(Guid companyId, Guid Id, bool trackChanges);
    }
}
