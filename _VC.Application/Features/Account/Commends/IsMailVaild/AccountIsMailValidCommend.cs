using _VC.Application.Features.Account.Commends.Mail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.IsMailVaild
{
    public class AccountIsMailValidCommend : IRequest<AccountMailResponse>
    {
        public string CodeVaildEmail { get; set; }
        public string Email {  get; set; }
    }
}
