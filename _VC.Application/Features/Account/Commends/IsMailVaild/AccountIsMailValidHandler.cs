using _VC.Application.Contents.MailServicesIntr;
using _VC.Application.Features.Account.Commends.Mail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.IsMailVaild
{
    public class AccountIsMailValidHandler : IRequestHandler<AccountIsMailValidCommend, AccountMailResponse>
    {
        private readonly IEmailServices email;

        public AccountIsMailValidHandler(IEmailServices email)
        {
            this.email = email;
        }

        public async Task<AccountMailResponse> Handle(AccountIsMailValidCommend request, CancellationToken cancellationToken)
        {
            var response = await email.IsMailValidAsync(request);

            return response;
        }
    }
}
