﻿using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
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
                var employeesDto = Employees.Select(c => new EmployeeDto(c.Id, c.Name ?? "", c.Age.ToString())); //Atencion
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
    }
}
