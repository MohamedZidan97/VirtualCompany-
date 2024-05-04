using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServices.IEmployee
{
    public interface ITaskExecutionService
    {



        // get all task 


        // done task


        Task<GeneralResponse> UpdateOrExecuteTaskService(TaskUpdateOrExecuteRequest request);



    }
}
