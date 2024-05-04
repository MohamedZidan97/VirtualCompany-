using _VC.Application.Features.Account.Commends.Mail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.ResetPassword
{
    public class AccountResetPasswordRequest 
    {
        public string Password { get; set; }

    }
}
