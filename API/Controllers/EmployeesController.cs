using API.DataAccess.DataObjects;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {

        private readonly IEmployeesRepository _employeeRepository;

        public EmployeesController(IEmployeesRepository employeerepository)
        {
            _employeeRepository = employeerepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employees = _employeeRepository.ListEmployees();
            return new OkObjectResult(employees);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var enterprise = _employeeRepository.SearchEmployees(id);
            return new OkObjectResult(enterprise);

        }

        [HttpPost]

        public IActionResult Post([FromBody] Employees e)
        {
            using (var scope = new TransactionScope())
            {
                _employeeRepository.CreateEmployees(e);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = e.Id }, e);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Employees e)
        {
            if (e != null)
            {
                using (var scope = new TransactionScope())
                {
                    _employeeRepository.EditEmployees(e);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
    }
}

        

