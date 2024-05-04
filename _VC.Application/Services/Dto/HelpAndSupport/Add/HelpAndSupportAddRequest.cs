using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.HelpAndSupport.Add
{
    public class HelpAndSupportAddRequest
    {
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual int VirtualCompanyId { get; set; }
    }
}
