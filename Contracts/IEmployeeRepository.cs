﻿using Entities.Models;
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
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
    }
}
