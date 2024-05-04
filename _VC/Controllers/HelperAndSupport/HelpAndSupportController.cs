using _VC.Application.Services.Dto.Chat.Add;
using _VC.Application.Services.Dto.HelpAndSupport.Add;
using _VC.Application.Services.IServices.IHelpAndSupport;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.HelperAndSupport
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpAndSupportController : ControllerBase
    {
        private readonly IHelpAndSupportService service;

        public HelpAndSupportController(IHelpAndSupportService service)
        {
            this.service = service;
        }

        [HttpPost("addSupport")]
        public async Task<IActionResult> AddSupport(HelpAndSupportAddRequest request)
        {
            var response = await service.AddHelpAndSupportService(request);
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }
          
    }
}
