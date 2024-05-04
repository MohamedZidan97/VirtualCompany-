using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.PaymentManagement.Add
{
    public class PaymentRequest
    {
        public string CardNumber { get; set; }

        public DateTime Expiry { get; set; }

        public string CVC { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public decimal CostService { get; set; }

        public virtual int VirtualCompanyId { get; set; }
    }
}
