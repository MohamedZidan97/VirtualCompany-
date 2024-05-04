using _VC.Application.Services.Dto.StokeHolder.Department.Add;
using _VC.Application.Services.Dto.StokeHolder.Department.AddEmpToDep;
using _VC.Application.Services.Dto.StokeHolder.Department.Update;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.Add;
using _VC.Application.Services.IServices.IStokeHolder;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _VC.Controllers.StokeHolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService service;

        public DepartmentController(IDepartmentService service)
        {
            this.service = service;
        }

        // Create Dep
        [HttpPost("addDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentAddRequest request)
        {

            var response = (await service.AddDepartmentService(request));
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }



        // update

        [HttpPut("updateDepartment")]
        public async Task<IActionResult> UpdateDepartment(DepartmentUpdateRequest request)
        {
            var response = (await service.UpdateDepartmentService(request));

            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }
        // delete
        [HttpDelete("deleteDepartment/{_DepartmentId}")]
        public async Task<IActionResult> DeleteDepartment(int _DepartmentId)
        {
            var response = (await service.DeleteDepartmentService(_DepartmentId));

            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }

        /////
        ///
        // Get all
        [HttpGet("getAllDepartments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            try
            {
                var response = await service.GetAllDepartmentsService();
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while fetching cost to virtual machine");

                return NotFound(new { message = "An error occurred while fetching cost to virtual machine", error = ex.Message });
            }
        }


        ////// logic

        // add employee to department
        [HttpPost("addEmployeeToDepartment")]
        public async Task<IActionResult> AddEmployeeToDepartment(AddEmployeeToDepartmentRequest request)
        {
            var response = (await service.AddEmployeeToDepartemntService(request));

            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }
        // delete employee 
        [HttpDelete("deleteEmployeeFromDepartment/{_EmployeeId}")]
        public async Task<IActionResult> DeleteEmployeeFromDepartment(string _EmployeeId)
        {
            var response = (await service.DeleteEmployeeFromDepartemntService(_EmployeeId));
            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }


        // get employee in department

        [HttpGet("getAllEmployeesInDepartments/{_DepartmentId}")]
        public async Task<IActionResult> GetAllEmployeesInDepartments(int _DepartmentId)
        {
            
            try
            {
                var response = await service.GetEmployeesFromDepartemntService(_DepartmentId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception
                // logger.LogError(ex, "An error occurred while fetching cost to virtual machine");

                return NotFound(new { message = "An error occurred while fetching cost to virtual machine", error = ex.Message });
            }
        }



        // assgin supervisor 

        [HttpPost("assignSupervisorToDepartment")]
        public async Task<IActionResult> AssignSupervisorToDepartment(AddEmployeeToDepartmentRequest request)
        {
            var response = (await service.AssignEmployeeToDepartemntService(request));

            if (!response.Done)
                return BadRequest(response.Message);

            return Ok(response);
        }






    }
}
