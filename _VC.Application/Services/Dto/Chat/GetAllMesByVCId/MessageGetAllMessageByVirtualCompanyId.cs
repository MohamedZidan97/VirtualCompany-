using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.Chat.GetAllMesByVCId
{
    public class MessageGetAllMessageByVirtualCompanyId
    {
        public int MessageId { get; set; }
        public string Text { get; set; }

        public string FullName { get; set; }

        public virtual string UserId { get; set; }
    }
}
