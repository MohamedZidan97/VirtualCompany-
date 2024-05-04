using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.Supervisor.Task.Add;
using _VC.Application.Services.Dto.Supervisor.Task.GetAllTaskByEmpId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServices.ISupervisor
{
    public interface ITaskManagementService
    {
        // add task
        Task<GeneralResponse> AddTaskService(TaskAddRequest request);
        // delete 
        Task<GeneralResponse> DeleteTaskService(int TaskId);

        // get all task by EmployeeId
        Task<IEnumerable<TaskGetAllTaskByEmpoyeeIdResponse>> GetAllTaskByEmpoyeeIdService(string employeeId);






    }
}
