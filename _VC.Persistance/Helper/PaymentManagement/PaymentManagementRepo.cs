using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.PaymentManagement;
using _VC.Application.Services.Dto.PaymentManagement.Add;
using _VC.Domain.Contents.Identites;
using _VC.Domain.Data.PaymentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance.Helper.PaymentManagement
{
    public class PaymentManagementRepo : IPaymentManagement
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public PaymentManagementRepo(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        public async Task<int> GetCountEmployeesOnCompanyAsync(int VirtualCompanyId)
            => (await userManager.Users.Where(e => e.VirtualCompanyId == VirtualCompanyId)
                .ToListAsync()).Count();




        public async Task<GeneralResponse> PaymentMethodAsync(Payment request,decimal _CostVM)
        {
            request.CostService=_CostVM;


            var RG = new GeneralResponse();

            try
            {
                await context.Set<Payment>().AddAsync(request);

                RG.Done = true;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or set RG.Done to false if needed.
                RG.Done = false;
                RG.Message = $"An error occurred: {ex.Message}";
            }

            return RG;
        }

  
    }
}
