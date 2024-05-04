using _VC.Application.Services.Dto.HelpAndSupport.Add;
using _VC.Application.Services.Dto.PaymentManagement.Add;
using _VC.Application.Services.IServices.IPaymentManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.Payment
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentManagementController : ControllerBase
    {
        private readonly IPaymentManagementService service;

        public PaymentManagementController(IPaymentManagementService service)
        {
            this.service = service;
        }

        [HttpPost("addPayment")]
        public async Task<IActionResult> AddPayment(PaymentRequest request)
        {
            var response = await service.PaymentMethodService(request);
            if (!response.Done)
               return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpGet("getCostToVirtualMachine/{_VirtualCompany}")]
        public async Task<IActionResult> GetCostToVirtualMachine(int _VirtualCompany)
        {
            try
            {
                var response = await service.GetCostToVirtualMachineService(_VirtualCompany);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while fetching cost to virtual machine");

                return NotFound(new { message = "An error occurred while fetching cost to virtual machine", error = ex.Message });
            }
        }

    }
}
