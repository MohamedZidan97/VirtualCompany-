using _VC.Domain.Data.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Domain.Data.HelpAnSupport
{
    public class Support
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual int VirtualCompanyId { get; set; }
        public virtual VirtualCompany VirtualCompany { get; set; }
    }
}
