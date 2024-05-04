using _VC.Application.Contents;
using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.Chat;
using _VC.Application.Services.Dto.Chat.Add;
using _VC.Application.Services.Dto.Chat.GetAllMesByVCId;
using _VC.Application.Services.IServices.IChat;
using _VC.Domain.Data.Chat;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServicesRepo.ChatService
{
    public class ChatService : IChatService
    {
        private readonly IChat rep2;
        private readonly IBaseRepositories<AddMessage> rep1;
        private readonly IMapper mapper;

        public ChatService(IChat rep2, IBaseRepositories<AddMessage> rep1, IMapper mapper)
        {
            this.rep2 = rep2;
            this.rep1 = rep1;
            this.mapper = mapper;
        }
        // get all by VC id
        public async Task<IEnumerable<MessageGetAllMessageByVirtualCompanyId>> GetMessagesByVirtualCompanyService(int virtualCompanyId)
           => mapper.ProjectTo<MessageGetAllMessageByVirtualCompanyId>((await rep2.GetMessagesByVirtualCompanyAsync(virtualCompanyId)).AsQueryable());





        ////
        ///
        //add message 

        public async Task<GeneralResponse> AddMessageService(MessageAddRequest request)
             => await rep1.AddAsync(mapper.Map<AddMessage>(request));

    }
}
