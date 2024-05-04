using _VC.Domain.Contents.Identites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Domain.Data.Task
{
    public class AddTask
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
        public string? FileUrl { get; set; }

        public string? FileUrlForDone { get; set; }

        public bool IsCompleted { get; set; } = false;

        public string? UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
    }
}
