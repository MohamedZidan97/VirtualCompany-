using _VC.Application.Services.Dto.Supervisor.Task.Add;
using _VC.Application.Services.IServices.ISupervisor;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.Supervisor
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupervisorController : ControllerBase
    {
        private readonly ITaskManagementService service;

        public SupervisorController(ITaskManagementService service)
        {
            this.service = service;
        }

        [HttpPost("addTaskToEmployee")]
        public async Task<IActionResult> AddTaskToEmployee(TaskAddRequest request)
        {
            var response = await service.AddTaskService(request);
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }
       

        [HttpDelete("deleteTask")]
        public async Task<IActionResult> DeleteTask(int TaskId)
        {
            var response = await service.DeleteTaskService(TaskId);
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }
        

        [HttpGet("getTaskHasEmployee/{_EmployeeId}")]
        public async Task<IActionResult> DeleteTask(string _EmployeeId)
        {
            try
            {
                var response = await service.GetAllTaskByEmpoyeeIdService(_EmployeeId);
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
