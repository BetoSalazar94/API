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
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentrepository)
        {
            _departmentRepository = departmentrepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var enterprises = _departmentRepository.ListDepartments();
            return new OkObjectResult(enterprises);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var enterprise = _departmentRepository.SearchDepartment(id);
            return new OkObjectResult(enterprise);

        }

        [HttpPost]

        public IActionResult Post([FromBody] Departments d)
        {
            using (var scope = new TransactionScope())
            {
                _departmentRepository.CreateDepartments(d);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = d.Id }, d);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Departments d)
        {
            if (d != null)
            {
                using (var scope = new TransactionScope())
                {
                    _departmentRepository.EditDepartments(d);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

    }
}
