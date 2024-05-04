using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Queries.GetToken
{
    public class AccountGetTokenRequest : IRequest<AccountGeneralResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
