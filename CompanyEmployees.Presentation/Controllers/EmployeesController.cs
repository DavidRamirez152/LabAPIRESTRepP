using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]        
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)=>        
            _service = service;

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _service.EmployeeService.GetAllEmployees(trackChanges:false);
                return Ok(employees);
            //try
            //{
            //    var employees =
            //        _service.EmployeeService.GetAllEmployees(trackChanges:false);
            //    return Ok(employees);
            //}
            //catch
            //{
            //    return StatusCode(500, "Internal server Error");
            //}
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _service.EmployeeService.GetEmployee(id, trackChanges: false);
            return Ok(employee);
        }
    }
}
