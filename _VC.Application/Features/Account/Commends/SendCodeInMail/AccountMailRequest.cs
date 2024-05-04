using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.Mail
{
    public class AccountMailRequest : IRequest<AccountMailResponse>
    {
        public string Email { get; set; }
    }
}
