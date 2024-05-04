using _VC.Application.Features.Account.Commends.ForgetPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Contents
{
    public interface IForgetPassword
    {
        Task<AccountForgetPasswordResponse> IsEmailFound(AccountForgetPasswordRequest request);


    }
}
