using _VC.Application.Features.GeneralResponsive;
using _VC.Domain.Data.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.IHelper.Supervisor
{
    public interface ITaskManagement
    {
        Task<IEnumerable<AddTask>> GetAllTaskByEmpoyeeIdAsync (string empyeeId);
    }
}
