using _VC.Domain.Contents.Identites;
using _VC.Domain.Data.Chat;
using _VC.Domain.Data.Department;
using _VC.Domain.Data.HelpAnSupport;
using _VC.Domain.Data.PaymentModel;
using _VC.Domain.Data.Task;
using _VC.Domain.Data.VM;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<EmployeeDepartment>().HasKey(e => new { e.EmployeeId, e.DepartmentId });
            builder.Entity<AddTask>().HasKey(e => e.TaskId);
            builder.Entity<AddMessage>().HasKey(e => e.MessageId);


            base.OnModelCreating(builder);
        }




        // DbSets
        public DbSet<VirtualMachine> virtualMachines { get; set; }
        public DbSet<VirtualCompany> virtualCompanies { get; set; }

        ///////
        /// <summary>
        /// 
        /// </summary>

        public DbSet<Department> departments { get; set; }

        public DbSet<EmployeeDepartment> employeeDepartments { get; set; }
        public DbSet<AddMessage> messages { get; set; }
        public DbSet<AddTask> tasks { get; set; }

        public DbSet<Support> supports {  get; set; }
        public DbSet<Payment> payments { get; set; }



    }
}
