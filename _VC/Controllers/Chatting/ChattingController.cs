using _VC.Application.Services.Dto.Chat.Add;
using _VC.Application.Services.IServices.IChat;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.Chatting
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChattingController : ControllerBase
    {
        private readonly IChatService service;

        public ChattingController(IChatService service)
        {
            this.service = service;
        }

        [HttpGet("getMessagesByVirtualCompany/{_VirtualCompanyId}")]
        public async Task<IActionResult> GetMessagesByVirtualCompanyAsync(int _VirtualCompanyId)
        {

            try
            {
                var response = await service.GetMessagesByVirtualCompanyService(_VirtualCompanyId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while fetching cost to virtual machine");

                return NotFound(new { message = "An error occurred while fetching cost to virtual machine", error = ex.Message });
            }
        }
       

        [HttpPost("addMessage")]
        public async Task<IActionResult> AddMessage(MessageAddRequest request)
        {
            var response = await service.AddMessageService(request);
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }
        


    }
}
