using _VC.Application.Features.Account.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Features.Account.Commends.Register
{
    public class AccountRegisterRequest : IRequest<AccountGeneralResponse>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string RoleName { get; set; }
    }
}
