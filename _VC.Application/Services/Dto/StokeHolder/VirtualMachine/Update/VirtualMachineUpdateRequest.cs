using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Update
{
    public class VirtualMachineUpdateRequest
    {
        public int VirtualMachineId { get; set; }

        public string OperatingSystem { get; set; }

        public double HDD { get; set; }
        public double SSD { get; set; }
        public double RAM { get; set; }

        public int VirtualCompanyId { get; set; }

    }
}
