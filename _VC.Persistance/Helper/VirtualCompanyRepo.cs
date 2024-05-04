using _VC.Application.IHelper.VC;
using _VC.Domain.Data.VM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _VC.Persistance.Helper
{
    public class VirtualCompanyRepo : IVirtualCompany
    {
        private readonly ApplicationDbContext context;

        public VirtualCompanyRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> CreateVirtualCompany()
        {


            var VC = new VirtualCompany();

            // Add the new VirtualCompany object to the context
            context.virtualCompanies.Add(VC);

            // Save changes asynchronously
            await context.SaveChangesAsync();

            // Return the newly created VirtualCompany object
            var vc = await context.virtualCompanies.MaxAsync(e => e.VirtualCompanyId);
          
            return vc;


        }


        public async Task<int> returnVirtualMachineId(int vcId)
        {
            var vmId = await context.virtualMachines.Where(x => x.VirtualCompanyId == vcId).FirstOrDefaultAsync();

            return vmId.VirtualMachineId;
            
        }
    }
}
