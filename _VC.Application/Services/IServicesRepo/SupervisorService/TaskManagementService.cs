using _VC.Application.Contents;
using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.Supervisor;
using _VC.Application.Services.Dto.Supervisor.Task.Add;
using _VC.Application.Services.Dto.Supervisor.Task.GetAllTaskByEmpId;
using _VC.Application.Services.IServices.ISupervisor;
using _VC.Domain.Data.Task;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServicesRepo.SupervisorService
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly ITaskManagement rep2;
        private readonly IBaseRepositories<AddTask> rep1;
        private readonly IMapper mapper;

        public TaskManagementService(ITaskManagement rep2, IBaseRepositories<AddTask> rep1, IMapper mapper)
        {
            this.rep2 = rep2;
            this.rep1 = rep1;
            this.mapper = mapper;
        }
        // add task
        public async Task<GeneralResponse> AddTaskService(TaskAddRequest request)
         => await rep1.AddAsync(mapper.Map<AddTask>(request));


        // delete 
        public async Task<GeneralResponse> DeleteTaskService(int TaskId)
            => await rep1.DeleteAsync(TaskId);

        // get all task by EmployeeId
        public async Task<IEnumerable<TaskGetAllTaskByEmpoyeeIdResponse>> GetAllTaskByEmpoyeeIdService(string employeeId)
            => mapper.ProjectTo<TaskGetAllTaskByEmpoyeeIdResponse>((await rep2.GetAllTaskByEmpoyeeIdAsync(employeeId)).AsQueryable());






    }
}
