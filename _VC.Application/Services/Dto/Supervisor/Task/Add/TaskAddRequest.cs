using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.Dto.Supervisor.Task.Add
{
    public class TaskAddRequest
    {
        public string? UserId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
        public string? FileUrl { get; set; }

        public string? FileUrlForDone { get; set; }

       

       
    }
}
