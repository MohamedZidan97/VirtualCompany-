using _VC.Domain.Data.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.IHelper.VC
{
    public interface IVirtualCompany
    {
        Task<int> CreateVirtualCompany();
        Task<int> returnVirtualMachineId(int id);
    }
}
