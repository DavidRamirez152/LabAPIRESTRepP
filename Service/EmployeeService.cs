using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool trackChanges)
        {
            try
            {
                var Employees = _repository.Employee.GetAllEmployees(trackChanges);
                //var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(Employees);
                var employeesDto = Employees.Select(e => new EmployeeDto(e.Id, e.Name ?? "", e.Age.ToString(), e.Position ?? "")); //Atencion
                return employeesDto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetAllEmployees)} service method {ex}");
                throw;
            }
        }
        public EmployeeDto GetEmployee(Guid id, bool trackChanges)
        {
            var employee = _repository.Employee.GetEmployee(id, trackChanges);

            if (employee == null)
            {
                throw new EmployeeNotFoundException(id);
            }

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid Id, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if(company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }
            var employeDb = _repository.Employee.GetEmployee(companyId, Id, trackChanges);
            if(employeDb is null)
            {
                throw new EmployeeNotFoundException(Id);
            }
            var employee = _mapper.Map<EmployeeDto>(employeDb);
            return employee;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }
            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return employeesDto;
        }
    }
}
