using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.StokeHolder;
using _VC.Application.Services.Dto.StokeHolder.VirtualCompany;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Add;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Get;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.GetById;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Update;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServices.IStokeHolder
{
    public interface IVirtualMachineService
    {
        Task<GeneralResponse> AddVirtualMachineAsync(VirtualMachineAddRequest dto);
        Task<GeneralResponse> UpdateVirtualMachineAsync(VirtualMachineUpdateRequest dto);
        Task<IEnumerable<VirtualMachineGetResponse>> GetVirtualMachinesAsync();
        Task<VirtualMachineGetByIdResponse> GetVirtualMachineByVCIdAsync(VirtualMachineGetByIdRequest dto);
        Task<GeneralResponse> UpdateVirtualCompanyService(VirtualCompanyUpdateRequest dto);
    }
}
