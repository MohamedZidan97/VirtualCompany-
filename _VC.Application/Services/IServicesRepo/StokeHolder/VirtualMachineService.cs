using _VC.Application.Contents;
using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.VC;
using _VC.Application.Services.Dto.StokeHolder;
using _VC.Application.Services.Dto.StokeHolder.VirtualCompany;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Add;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Get;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.GetById;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Update;
using _VC.Application.Services.IServices.IStokeHolder;
using _VC.Domain.Data.VM;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServicesRepo.StokeHolder
{
    public class VirtualMachineService : IVirtualMachineService
    {
        private readonly IBaseRepositories<VirtualCompany> rep2;
        private readonly IBaseRepositories<VirtualMachine> rep;

        private readonly IMapper mapper;
        private readonly IVirtualCompany helper;

        public VirtualMachineService(IBaseRepositories<VirtualCompany> rep2,IBaseRepositories<VirtualMachine> rep, IMapper mapper, IVirtualCompany helper)
        {
            this.rep2 = rep2;
            this.rep = rep;
            this.mapper = mapper;
            this.helper = helper;
        }
        public async Task<GeneralResponse> AddVirtualMachineAsync(VirtualMachineAddRequest dto)
        {

            var _mapper = mapper.Map<VirtualMachine>(dto);
            var response = await rep.AddAsync(_mapper);

            return response;

        }

        public async Task<VirtualMachineGetByIdResponse> GetVirtualMachineByVCIdAsync(VirtualMachineGetByIdRequest dto)
        {
            var VirtualMachineID = await helper.returnVirtualMachineId(dto.VirtualCompanyId);

            var VM = await rep.GetByIdAsync(VirtualMachineID);

            var response = mapper.Map<VirtualMachineGetByIdResponse>(VM);

            return response;

        }

        public async Task<IEnumerable<VirtualMachineGetResponse>> GetVirtualMachinesAsync()
        {
            var allRows = await rep.GetAllAsync();
            var response = mapper.ProjectTo<VirtualMachineGetResponse>(allRows.AsQueryable());


            return response;
        }

        public async Task<GeneralResponse> UpdateVirtualMachineAsync(VirtualMachineUpdateRequest dto)
        {

            var _mapper = mapper.Map<VirtualMachine>(dto);

            var response = await rep.UpdateAsync(_mapper);

            return response;
        }

        public async Task<GeneralResponse> UpdateVirtualCompanyService(VirtualCompanyUpdateRequest dto)
         => await rep2.UpdateAsync(mapper.Map<VirtualCompany>(dto));

        

    }
}
