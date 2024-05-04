using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.HelpAndSupport.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServices.IHelpAndSupport
{
    public interface IHelpAndSupportService
    {
        // add


        Task<GeneralResponse> AddHelpAndSupportService(HelpAndSupportAddRequest request);


    }
}
