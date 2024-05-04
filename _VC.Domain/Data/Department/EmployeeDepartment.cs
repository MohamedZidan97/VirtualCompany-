using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Domain.Data.Department
{
    public class EmployeeDepartment
    {
       
        public string EmployeeId { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Departments { get; set; }
    }
}
