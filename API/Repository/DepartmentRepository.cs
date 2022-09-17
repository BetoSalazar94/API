using API.DataAccess.DataObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class DepartmentRepository:IDepartmentRepository
    {

        private readonly mydbContext _dbContext;

        public DepartmentRepository(mydbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Departments> ListDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public void CreateDepartments(Departments e)
        {
            _dbContext.Add(e);
            _dbContext.SaveChanges();
        }


        public void EditDepartments(Departments e)
        {

            _dbContext.Entry(e).State = EntityState.Modified;
            _dbContext.SaveChanges();

        }

        public Departments SearchDepartment(int id)
        {
            return _dbContext.Departments.Find(id);

        }

    }
}
