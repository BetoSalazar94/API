using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class EnterpriseRepository : IEnterprisesRepository
    {

        private readonly mydbContext _dbContext;

        public EnterpriseRepository(mydbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Enterprises> ListEnterprises()
        {
            return _dbContext.Enterprises.ToList();
        }

        public void CreateEnterprises(Enterprises e)
        {
            _dbContext.Add(e);
            _dbContext.SaveChanges();
        }


        public void EditEnterprises(Enterprises e)
        {

            _dbContext.Entry(e).State = EntityState.Modified;
            _dbContext.SaveChanges();

        }

        public Enterprises SearchEnterprise(int id)
        {
            return _dbContext.Enterprises.Find(id);

        }

    }
}
