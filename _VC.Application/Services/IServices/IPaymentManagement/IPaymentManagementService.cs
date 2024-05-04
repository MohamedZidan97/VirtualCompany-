using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.PaymentManagement.Add;
using _VC.Application.Services.Dto.PaymentManagement.GetCost;
using _VC.Domain.Data.PaymentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServices.IPaymentManagement
{
    public interface IPaymentManagementService
    {

        // send cost

        Task<PaymentGetCostVirtualMachinesResponse> GetCostToVirtualMachineService(int VirtualCompanyId);
        Task<GeneralResponse> PaymentMethodService(PaymentRequest request);


    }
}
