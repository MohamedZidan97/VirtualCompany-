using _VC.Application.Services.Dto.Employee;
using _VC.Application.Services.IServices.IEmployee;
using _VC.Application.Services.IServices.IStokeHolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly ITaskExecutionService service;

        public EmployeeController(ITaskExecutionService service)
        {
            this.service = service;
        }


        [HttpPut("updateOrExecuteTask")]
        public async Task<IActionResult> UpdateOrExecuteTask(TaskUpdateOrExecuteRequest request)
        {

            var response = await service.UpdateOrExecuteTaskService(request);
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }




    }
}
