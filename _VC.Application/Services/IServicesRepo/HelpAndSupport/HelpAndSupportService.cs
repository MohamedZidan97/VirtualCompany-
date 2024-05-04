using _VC.Application.Contents;
using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.HelpAndSupport.Add;
using _VC.Application.Services.IServices.IHelpAndSupport;
using _VC.Domain.Data.HelpAnSupport;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServicesRepo.HelpAndSupport
{
    public class HelpAndSupportService : IHelpAndSupportService
    {
        private readonly IBaseRepositories<Support> rep1;
        private readonly IMapper mapper;

        public HelpAndSupportService(IBaseRepositories<Support> rep1,IMapper mapper )
        {
            this.rep1 = rep1;
            this.mapper = mapper;
        }


        public async Task<GeneralResponse> AddHelpAndSupportService(HelpAndSupportAddRequest request)
             => await rep1.AddAsync(mapper.Map<Support>(request));

      
    }
}
