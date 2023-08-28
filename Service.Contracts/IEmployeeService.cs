using Entities.Models;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges);
        EmployeeDto GetEmployee(Guid employeeId, bool trackChanges);
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
        EmployeeDto GetEmployee(Guid companyId, Guid Id, bool trackChanges);
    }
}
