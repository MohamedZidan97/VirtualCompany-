using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById
{
    public class EmployeeManagementGetEmployeeByVirtualCompanyIdResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int? VirtualMachineId { get; set; }

        public int? VirtualCompanyId { get; set;}
    }
}
