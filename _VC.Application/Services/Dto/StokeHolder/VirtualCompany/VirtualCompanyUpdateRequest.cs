using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.StokeHolder.VirtualCompany
{
    public class VirtualCompanyUpdateRequest
    {
        public int VirtualCompanyId { get; set; }
        public string? Name { get; set; }

        public string? prodect { get; set; }

        public string? Description { get; set; }
    }
}
