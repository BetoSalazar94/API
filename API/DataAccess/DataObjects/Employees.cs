using System;
using System.Collections.Generic;

namespace API.DataAccess.DataObjects
{
    public partial class Employees
    {
        public Employees()
        {
            DepartmentsEmployees = new HashSet<DepartmentsEmployees>();
        }

        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte? Status { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<DepartmentsEmployees> DepartmentsEmployees { get; set; }
    }
}
