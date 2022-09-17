using System;
using System.Collections.Generic;

namespace API.DataAccess.DataObjects
{
    public partial class DepartmentsEmployees
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte? Status { get; set; }
        public int? IdDepartment { get; set; }
        public int? IdEmployee { get; set; }
        public int DepartmentsId { get; set; }
        public int EmployeesId { get; set; }

        public virtual Departments Departments { get; set; }
        public virtual Employees Employees { get; set; }
    }
}
