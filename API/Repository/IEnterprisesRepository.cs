using API.DataAccess.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Repository
{
    public interface IEnterprisesRepository
    {

        List<Enterprises> ListEnterprises();
        void CreateEnterprises(Enterprises e);
        void EditEnterprises(Enterprises e);

        Enterprises SearchEnterprise(int id);

    }
}
