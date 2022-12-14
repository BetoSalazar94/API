using System;
using System.Collections.Generic;

namespace API.DataAccess.DataObjects
{
    public partial class Departments
    {
        public Departments()
        {
            DepartmentsEmployees = new HashSet<DepartmentsEmployees>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte? Status { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int? IdEnterprise { get; set; }
        public int EnterprisesId { get; set; }

        public virtual Enterprises Enterprises { get; set; }
        public virtual ICollection<DepartmentsEmployees> DepartmentsEmployees { get; set; }
    }
}
