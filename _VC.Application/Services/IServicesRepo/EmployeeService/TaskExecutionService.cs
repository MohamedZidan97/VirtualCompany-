using _VC.Application.Contents;
using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.Employee;
using _VC.Application.Services.IServices.IEmployee;
using _VC.Domain.Data.Task;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServicesRepo.EmployeeService
{
    public class TaskExecutionService : ITaskExecutionService
    {
        private readonly IBaseRepositories<AddTask> rep;
        private readonly IMapper mapper;

        public TaskExecutionService(IBaseRepositories<AddTask> rep,IMapper mapper)
        {
            this.rep = rep;
            this.mapper = mapper;
        }
        public async Task<GeneralResponse> UpdateOrExecuteTaskService(TaskUpdateOrExecuteRequest request)
          => await rep.UpdateAsync(mapper.Map<AddTask>(request));

        

    }
}
