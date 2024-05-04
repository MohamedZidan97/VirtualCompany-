using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Get
{
    public class VirtualMachineGetResponse
    {
        public int VirtualMachineId { get; set; }

        public string OperatingSystem { get; set; }

        public double HDD { get; set; }
        public double SSD { get; set; }
        public double RAM { get; set; }

        public int VirtualCompanyId { get; set; }


    }
}
