using _VC.Domain.Data.VM;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Domain.Contents.Identites
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? CodeVaildEmail { get; set; }
        public virtual int? VirtualCompanyId { get; set; }
        public virtual VirtualCompany? VirtualCompany { get; set; }
    }
}
