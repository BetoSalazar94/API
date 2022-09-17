using API.DataAccess.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public interface IDepartmentRepository
    {
        List<Departments> ListDepartments();
        void CreateDepartments(Departments e);
        void EditDepartments(Departments e);

        Departments SearchDepartment(int id);

    }
}
