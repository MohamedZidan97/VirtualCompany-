using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.PaymentManagement.Add;
using _VC.Application.Services.Dto.PaymentManagement.GetCost;
using _VC.Domain.Data.PaymentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.IHelper.PaymentManagement
{
    public interface IPaymentManagement
    {
        Task<int> GetCountEmployeesOnCompanyAsync(int VirtualCompanyId); 
        Task<GeneralResponse> PaymentMethodAsync(Payment request, decimal _CostVM);
    }
}
