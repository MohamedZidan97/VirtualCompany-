using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.Supervisor.Task.GetAllTaskByEmpId
{
    public class TaskGetAllTaskByEmpoyeeIdResponse
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
        public string? FileUrl { get; set; }

        public string? FileUrlForDone { get; set; }

        public bool IsCompleted { get; set; } = false;
    }
}
