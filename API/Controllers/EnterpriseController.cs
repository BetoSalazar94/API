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
    public class EnterpriseController : Controller
    {

        private readonly IEnterprisesRepository _enterpriseRepository;

       public EnterpriseController(IEnterprisesRepository enterpriserepository)
        {
            _enterpriseRepository = enterpriserepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var enterprises = _enterpriseRepository.ListEnterprises();
            return new OkObjectResult(enterprises);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var enterprise = _enterpriseRepository.SearchEnterprise(id);
            return new OkObjectResult(enterprise);

        }

        [HttpPost]

        public IActionResult Post([FromBody] Enterprises enterprise)
        {
            using (var scope = new TransactionScope())
            {
                _enterpriseRepository.CreateEnterprises(enterprise);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = enterprise.Id }, enterprise);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Enterprises enterprise)
        {
            if (enterprise != null)
            {
                using (var scope = new TransactionScope())
                {
                    _enterpriseRepository.EditEnterprises(enterprise);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

    }
}
