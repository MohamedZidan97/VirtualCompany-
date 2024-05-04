using _VC.Domain.Contents.Identites;
using _VC.Domain.Data.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Domain.Data.Chat
{
    public class AddMessage
    {
        public int MessageId { get; set; }
        public string Text { get; set; }

        public string FullName { get; set; }

        public virtual string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public int VirtualCompanyId { get; set; }
        public virtual VirtualCompany VirtualCompany { get; set; }
    }
}
