using _VC.Domain.Contents.Identites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.Chat.Add
{
    public class MessageAddRequest
    {
        public string Text { get; set; }

        public string FullName { get; set; }

        public virtual string UserId { get; set; }


        public int VirtualCompanyId { get; set; }
    }
}
