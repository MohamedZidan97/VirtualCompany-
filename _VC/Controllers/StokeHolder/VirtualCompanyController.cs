using _VC.Application.Services.Dto.StokeHolder.VirtualCompany;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Add;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.GetById;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Update;
using _VC.Application.Services.IServices.IStokeHolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.StokeHolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class VirtualCompanyController : ControllerBase
    {
        private readonly IVirtualMachineService service;

        public VirtualCompanyController(IVirtualMachineService service)
        {
            this.service = service;
        }

        [HttpPut("updateVirtualCompany")]
        public async Task<IActionResult> UpdateVirtualCompany(VirtualCompanyUpdateRequest request)
        {
            var response = await service.UpdateVirtualCompanyService(request);


            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpGet("getAllVirtualMachine")]
        public async Task<IActionResult> GetAllVirtualMachines()
        {

            try
            {
                var response = await service.GetVirtualMachinesAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while fetching cost to virtual machine");

                return NotFound(new { message = "An error occurred while fetching cost to virtual machine", error = ex.Message });
            }
        }

        [HttpPost("addVirtualMachine")]
        public async Task<IActionResult> AddVirtualMachine(VirtualMachineAddRequest request)
        {
            var response = await service.AddVirtualMachineAsync(request);

            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpPut("updateVirtualMachine")]
        public async Task<IActionResult> UpdateVirtualMachine(VirtualMachineUpdateRequest request)
        {
            var response = await service.UpdateVirtualMachineAsync(request);


            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }

        [HttpGet("getVirtualMachineByVirtualCompanyId/{_VirtualCompanyId}")]
        public async Task<IActionResult> GetByIdVirtualMachine(int _VirtualCompanyId)
        {
           var request = new VirtualMachineGetByIdRequest() { VirtualCompanyId = _VirtualCompanyId };
            try
            {
                var response = await service.GetVirtualMachineByVCIdAsync(request);
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
