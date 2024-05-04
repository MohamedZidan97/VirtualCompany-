using _VC.Domain.Contents.Identites;
using _VC.Domain.Data.Chat;
using _VC.Domain.Data.HelpAnSupport;
using _VC.Domain.Data.PaymentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Domain.Data.VM
{
    public class VirtualCompany
    {
        public int VirtualCompanyId { get; set; }
        public string? Name { get; set; }

        public string? prodect { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<VirtualMachine> VirtualMachines { get; set; }
        public virtual ICollection<ApplicationUser>? Users { get; set; }
        public virtual ICollection<AddMessage>? Messages { get; set; }
        public virtual ICollection<Support>? HelpAndSupports { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }


    }
}
