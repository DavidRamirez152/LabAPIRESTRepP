using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) 
            : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) =>
            FindAll(trackChanges)
            .OrderBy(e => e.Name)
            .ToList();
        public Employee GetEmployee(Guid employeeId, bool trackChanges) =>
            FindByCondition(e => e.Id.Equals(employeeId), trackChanges)
            .SingleOrDefault();


        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
            FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name)
            .ToList();
        public Employee GetEmployee(Guid companyId, Guid Id, bool trackChanges) =>
            FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id == (Id), trackChanges)
            .SingleOrDefault();
    }
}
