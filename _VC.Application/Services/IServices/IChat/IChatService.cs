using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.Chat.Add;
using _VC.Application.Services.Dto.Chat.GetAllMesByVCId;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServices.IChat
{
    public interface IChatService
    {
        // get all by VC id
      Task<IEnumerable<MessageGetAllMessageByVirtualCompanyId>> GetMessagesByVirtualCompanyService(int virtualCompanyId);


        ////
        ///
        //add message 

        Task<GeneralResponse> AddMessageService (MessageAddRequest request);

    }
}
