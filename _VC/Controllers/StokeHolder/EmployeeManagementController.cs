using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.Add;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using _VC.Application.Services.IServices.IStokeHolder;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.StokeHolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {

        private readonly IEmployeesManagementService service;

        public EmployeeManagementController(IEmployeesManagementService service)
        {
            this.service = service;
        }

        [HttpPost("addEmployeeToCompany")]
        public async Task<IActionResult> AddEmployeeToCompany(EmployeeManagementAddRequest request)
        {
            var response = (await service.AddEmployeeToComapanyService(request));
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }
        [HttpGet("getEmployeesById/{_EmployeeId}")]
        public async Task<IActionResult> GetEmployeesByVirtualCompanyId(string _EmployeeId)
        {
            try
            {
                var response = await service.GetEmployeeById(_EmployeeId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while fetching cost to virtual machine");

                return NotFound(new { message = "An error occurred while fetching cost to virtual machine", error = ex.Message });
            }
        }

        [HttpGet("getEmployeesByVirtualCompanyId/{_VirtualCompanyId}")]
        public async Task<IActionResult> GetEmployeesByVirtualCompanyId(int _VirtualCompanyId)
        {
            var request = new EmployeeManagementGetEmployeeByVirtualCompanyIdRequest { VirtualCompanyId = _VirtualCompanyId };

            try
            {
                var response = await service.GetEmployeesByVirtualCompanyId(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while fetching cost to virtual machine");

                return NotFound(new { message = "An error occurred while fetching cost to virtual machine", error = ex.Message });
            }
        }

        [HttpDelete("deleteEmployeeToCompany/{_EmployeeId}")]
        public async Task<IActionResult> DeleteEmployeeToCompany(string _EmployeeId)
        {
            var response = (await service.DeleteEmployeeFromComapanyService(_EmployeeId));
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }


    }
}
