using _VC.Application.Contents.MailServicesIntr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.Mail
{
    public class AccountMailHandler : IRequestHandler<AccountMailRequest, AccountMailResponse>
    {
        private readonly IEmailServices mail;

        public AccountMailHandler(IEmailServices mail)
        {
            this.mail = mail;
        }

        public async Task<AccountMailResponse> Handle(AccountMailRequest request, CancellationToken cancellationToken)
        {
            var response = await mail.SendCodeToEmail(request);

            return response;
        }
    }
}
