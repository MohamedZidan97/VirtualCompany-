using _VC.Application.Contents.MailServicesIntr;
using _VC.Application.Features.Account.Commends.Mail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.ResetPassword
{
    public class AccountResetPasswordHandler : IRequestHandler<AccountResetPasswordCommend, AccountMailResponse>
    {
        private readonly IEmailServices email;

        public AccountResetPasswordHandler(IEmailServices email)
        {
            this.email = email;
        }
        public async Task<AccountMailResponse> Handle(AccountResetPasswordCommend request, CancellationToken cancellationToken)
        {
            return await email.CreateNewPassword(request);
        }
    }
}
