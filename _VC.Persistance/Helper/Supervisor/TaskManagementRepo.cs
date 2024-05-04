using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.Supervisor;
using _VC.Domain.Data.Task;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance.Helper.Supervisor
{
    public class TaskManagementRepo : ITaskManagement
    {
        private readonly ApplicationDbContext context;

        public TaskManagementRepo(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<AddTask>> GetAllTaskByEmpoyeeIdAsync(string empyeeId)
        {
            var tasks = await context.tasks.Where(e=>e.UserId== empyeeId).ToListAsync();

            return tasks;
        }

    }
}
