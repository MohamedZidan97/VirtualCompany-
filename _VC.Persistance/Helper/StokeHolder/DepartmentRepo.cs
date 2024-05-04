using _VC.Application.Contents;
using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.StokeHolder;
using _VC.Application.Services.Dto.StokeHolder.Department.Add;
using _VC.Application.Services.Dto.StokeHolder.Department.AddEmpToDep;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using _VC.Domain.Contents.Enums;
using _VC.Domain.Contents.Identites;
using _VC.Domain.Data.Department;
using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance.Helper.StokeHolder
{
    public class DepartmentRepo : IDepartment
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;
        private readonly IBaseRepositories<EmployeeDepartment> rep1;
        private readonly IBaseRepositories<Department> rep;
        private readonly IMapper mapper;

        public DepartmentRepo(UserManager<ApplicationUser> userManager, ApplicationDbContext context, IBaseRepositories<EmployeeDepartment> rep1, IBaseRepositories<Department> rep, IMapper mapper)
        {
            this.userManager = userManager;
            this.context = context;
            this.rep1 = rep1;
            this.rep = rep;
            this.mapper = mapper;
        }

        // Get By Id



        ////// logic

        // add employee to department
        public async Task<GeneralResponse> AddEmployeeToDepartemntAsync(AddEmployeeToDepartmentRequest request)
          => await rep1.AddAsync(mapper.Map<EmployeeDepartment>(request));




        // delete employee from department
        public async Task<GeneralResponse> DeleteEmployeeFromDepartemntAsync(string employeeId)
        {
            // Find the employee entity by id
            var user = await context.employeeDepartments.Where(e=>e.EmployeeId==employeeId).FirstOrDefaultAsync();

            if (user == null)
            {
                return new GeneralResponse { Message = "Employee not found" };
            }

            // Remove the employee entity
          var result = context.employeeDepartments.Remove(user);




            try
            {
                // Save changes to the database
                await context.SaveChangesAsync();

                // If SaveChangesAsync() completes without throwing an exception, the removal was successful
                return new GeneralResponse { Done = true, Message = "Employee deleted from company successfully" };
            }
            catch (Exception ex)
            {
                // Handle error if the delete operation failed
                return new GeneralResponse { Message = $"Failed to delete employee from company: {ex.Message}" };
            }

        }



        // get employee in department

      public async Task<IEnumerable<EmployeesManagementGetByIdResponse>> GetEmployeeFromDepartemntAsync(int departmentId)
        {

            var users = userManager.Users;

            var joinTb = await (from department in context.departments
                                join EmpDep in context.employeeDepartments
                                on department.DepartmentId equals EmpDep.DepartmentId
                                join user in users
                                on EmpDep.EmployeeId equals user.Id
                                select new EmployeesManagementGetByIdResponse
                                {
                                    Id = user.Id,
                                    Email = user.Email,
                                    FullName = user.FullName
                                }
                                ).ToListAsync();



            return joinTb;

        }

        // assgin supervisor 

        public async Task<GeneralResponse> AssignEmployeeToDepartemntAsync(AddEmployeeToDepartmentRequest request)
        {
            var dep = await context.departments.FindAsync(request.DepartmentId);

            dep.SupervisorId = request.EmployeeId;


           var result = context.departments.Update(dep);

            try
            {
                var user = await userManager.FindByIdAsync(request.EmployeeId);
                await userManager.AddToRoleAsync(user, ERoles.Supervisor.ToString());
                // Save changes to the database
                await context.SaveChangesAsync();

                // If SaveChangesAsync() completes without throwing an exception, the removal was successful
                return new GeneralResponse { Done = true, Message = "Employee deleted from company successfully" };
            }
            catch (Exception ex)
            {
                // Handle error if the delete operation failed
                return new GeneralResponse { Message = $"Failed to delete employee from company: {ex.Message}" };
            }

        }

    }
}
