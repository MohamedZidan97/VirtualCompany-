using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Domain.Data.Department
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string Name { get; set; }

        public string? SupervisorId { get; set; }

        public virtual ICollection<EmployeeDepartment> Employees { get; set; }
    }
}
