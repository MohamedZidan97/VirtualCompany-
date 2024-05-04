using _VC.Application.Contents;
using _VC.Application.Features.Account.Commends.ForgetPassword;
using _VC.Domain.Contents.Identites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance.Repositories
{
    public class ForgetPassword : IForgetPassword
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ForgetPassword(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<AccountForgetPasswordResponse> IsEmailFound(AccountForgetPasswordRequest request)
        {

          

            var User = await userManager.FindByEmailAsync(request.Email);

            var response = new AccountForgetPasswordResponse();
             
            if(User != null)
            {
                response.IsFound = true;
                response.Message = " Check Your Email";
            }
            else {
                response.Message = "Your Email is Not Found";      
            }

           return response;
            
        }
    }
}
