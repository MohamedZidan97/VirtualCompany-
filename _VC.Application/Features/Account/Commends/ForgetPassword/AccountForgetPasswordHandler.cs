using _VC.Application.Contents;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.ForgetPassword
{
    public class AccountForgetPasswordHandler : IRequestHandler<AccountForgetPasswordRequest, AccountForgetPasswordResponse>
    {
        private readonly IForgetPassword forget;

        public AccountForgetPasswordHandler(IForgetPassword forget)
        {
            this.forget = forget;
        }
        public async Task<AccountForgetPasswordResponse> Handle(AccountForgetPasswordRequest request, CancellationToken cancellationToken)
        {
            var response = await forget.IsEmailFound(request);

            return response;
        }
    }

}
