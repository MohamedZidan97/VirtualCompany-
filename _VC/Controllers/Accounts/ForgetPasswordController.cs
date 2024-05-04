using _VC.Application.Features.Account.Commends.ForgetPassword;
using _VC.Application.Features.Account.Commends.IsMailVaild;
using _VC.Application.Features.Account.Commends.Mail;
using _VC.Application.Features.Account.Commends.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace _VC.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgetPasswordController : ControllerBase
    {
        private readonly IMediator mediator;

        public ForgetPasswordController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("forgetPassword")]
        public async Task<IActionResult> ForgetPassword([FromBody] AccountMailRequest request)
        {
            var response = await mediator.Send(request);

            if (!response.Success)
                return NotFound(response.Message);


            return Ok(response.Message);
        }

        [HttpPost("isCodeValid/{Email}")]
        public async Task<IActionResult> IsCodeValid(string Email, [FromBody] AccountIsMailValidRequest request)
        {

            var commend = new AccountIsMailValidCommend
            {
                Email = Email,
                CodeVaildEmail = request.CodeVaildEmail
            };

            var response = await mediator.Send(commend);

            if (!response.Success)
                return BadRequest(response.Message);


            return Ok(response.Message);
        }
        
        [HttpPost("resetPassword/{Email}")]
        public async Task<IActionResult> ResetPassword(string Email, [FromBody] AccountResetPasswordRequest request)
        {
            var commend = new AccountResetPasswordCommend() { Email = Email, Password= request.Password };
            
            var response = await mediator.Send(commend);

            if (!response.Success)
                return BadRequest(response.Message);

            return Ok(response.Message);
        }
        

    }
}
