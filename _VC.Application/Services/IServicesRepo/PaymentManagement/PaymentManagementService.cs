using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.PaymentManagement;
using _VC.Application.Services.Dto.PaymentManagement.Add;
using _VC.Application.Services.Dto.PaymentManagement.GetCost;
using _VC.Application.Services.IServices.IPaymentManagement;
using _VC.Domain.Data.PaymentModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServicesRepo.PaymentManagement
{
    public class PaymentManagementService : IPaymentManagementService
    {
        private readonly IPaymentManagement rep;
        private readonly IMapper mapper;

        public PaymentManagementService(IPaymentManagement rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
     public async Task<PaymentGetCostVirtualMachinesResponse> GetCostToVirtualMachineService(int VirtualCompanyId)
            => new PaymentGetCostVirtualMachinesResponse
               {
                   CostService = await rep.GetCountEmployeesOnCompanyAsync(VirtualCompanyId) * 5000
               };


        public async Task<GeneralResponse> PaymentMethodService(PaymentRequest request)
         => await rep.PaymentMethodAsync(mapper.Map<Payment>(request),request.CostService);

        

    }
}
