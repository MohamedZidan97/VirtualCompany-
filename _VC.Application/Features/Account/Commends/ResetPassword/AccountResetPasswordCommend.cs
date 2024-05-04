using _VC.Application.Features.Account.Commends.Mail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.ResetPassword
{
    public class AccountResetPasswordCommend : IRequest<AccountMailResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
