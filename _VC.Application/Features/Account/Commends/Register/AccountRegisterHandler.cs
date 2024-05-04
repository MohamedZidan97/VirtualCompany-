using _VC.Application.Contents;
using _VC.Application.Features.Account.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.Register
{
    public class AccountRegisterHandler : IRequestHandler<AccountRegisterRequest, AccountGeneralResponse>
    {
        private readonly IAuthService auth;

        public AccountRegisterHandler(IAuthService auth)
        {
            this.auth = auth;
        }
        public async Task<AccountGeneralResponse> Handle(AccountRegisterRequest request, CancellationToken cancellationToken)
        {
            var response = await auth.RegisterAsync(request);

            return response;
        }
    }
}
