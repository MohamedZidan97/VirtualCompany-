using _VC.Domain.Data.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Domain.Data.PaymentModel
{
    public class Payment
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime Expiry { get; set; }

        public string CVC {  get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public decimal? CostService { get; set; }

        public virtual int VirtualCompanyId { get; set; }
        public virtual VirtualCompany VirtualCompany { get; set; }

    }
}
