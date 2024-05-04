using _VC.Application.Contents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Queries.GetToken
{
    public class AccountGetTokenHandler : IRequestHandler<AccountGetTokenRequest, AccountGeneralResponse>
    {
        private readonly IAuthService auth;

        public AccountGetTokenHandler(IAuthService auth)
        {
            this.auth = auth;
        }


        public async Task<AccountGeneralResponse> Handle(AccountGetTokenRequest request, CancellationToken cancellationToken)
        {
            var response = await auth.GetTokenAsync(request);

            return response;
        }
    }
}
