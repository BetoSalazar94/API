using API.DataAccess.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public interface IEmployeesRepository
    {

        List<Employees> ListEmployees();
        void CreateEmployees(Employees e);
        void EditEmployees(Employees e);

        Employees SearchEmployees(int id);


    }
}
