using _VC.Application.Features.Account.Commends.Register;
using _VC.Application.Features.Account.Queries;
using _VC.Application.Features.Account.Queries.GetToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Contents
{
    public interface IAuthService
    {
        Task<AccountGeneralResponse> RegisterAsync(AccountRegisterRequest request);

        Task<AccountGeneralResponse> GetTokenAsync(AccountGetTokenRequest request);

        // Task<string> AddRoleAsync(AddRoleM roleM);

        //Task<AccountGeneralResponse> CheckOrCreateRefreshTokenAsync(string refreshToken);

        // if you want Revoked for token is active, use this method
        //Task<bool> RevokedTokenAsync(string refreshToken);
    }
}
