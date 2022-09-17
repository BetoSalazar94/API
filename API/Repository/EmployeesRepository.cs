using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataAccess.DataObjects;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class EmployeesRepository:IEmployeesRepository
    {

        private readonly mydbContext _dbContext;

        public EmployeesRepository(mydbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Employees> ListEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public void CreateEmployees(Employees e)
        {
            _dbContext.Add(e);
            _dbContext.SaveChanges();
        }


        public void EditEmployees(Employees e)
        {

            _dbContext.Entry(e).State = EntityState.Modified;
            _dbContext.SaveChanges();

        }

        public Employees SearchEmployees(int id)
        {
            return _dbContext.Employees.Find(id);

        }

    }
}
