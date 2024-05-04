using _VC.Application.Features.Account.Commends.Register;
using _VC.Application.Features.Account.Queries.GetToken;
using _VC.Persistance.Helper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.Accounts
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly SendListRepo send;

        public AccountController(IMediator mediator, SendListRepo send)
        {
            this.mediator = mediator;
            this.send = send;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AccountRegisterRequest request)
        {
            var resopnse = await mediator.Send(request);

            if (!resopnse.IsAuthenticed)
                return BadRequest(resopnse.Message);


            return Ok(resopnse);
        }

        [HttpGet("listRolesInterface")]
        public async Task<IActionResult> ListRolesInterface()
        {
            var list = await send.ListRolesAsync();

            return Ok(list);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AccountGetTokenRequest request)
        {
            var resopnse = await mediator.Send(request);

            if (!resopnse.IsAuthenticed)
                return BadRequest(resopnse.Message);


            return Ok(resopnse);
        }


    }
}
