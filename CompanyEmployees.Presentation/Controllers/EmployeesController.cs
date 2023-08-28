using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/companies/{companyId}/employees")]
    [ApiController]        
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service) => _service = service;

        //[HttpGet]
        //public IActionResult GetEmployees()
        //{
        //    var employees = _service.EmployeeService.GetAllEmployees(trackChanges: false);
        //    return Ok(employees);
        //}

        //[HttpGet("{id:guid}", Name = "EmployeeById")]

        //public IActionResult GetEmployee(Guid id)
        //{
        //    var employee = _service.EmployeeService.GetEmployee(id, trackChanges: false);
        //    return Ok(employee);
        //}

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = _service.EmployeeService.GetEmployeesCompany(companyId, trackChanges: false);
            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = _service.EmployeeService.GetEmployeeCompany(companyId, id, trackChanges: false);
            return Ok(employee);
        }
    }
}
