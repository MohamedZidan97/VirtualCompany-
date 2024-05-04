using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.StokeHolder;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.Add;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using _VC.Domain.Contents.Identites;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance.Helper.StokeHolder
{
    public class EmployeeManagementRepo : IEmployeeManagement
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public EmployeeManagementRepo(UserManager<ApplicationUser> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }


        public async Task<GeneralResponse> AddEmployeeToComapanyAsync(EmployeeManagementAddRequest request)
        {
            
            var user = await userManager.FindByIdAsync(request.Id);

            
             
            if (user == null)
            {
                return new GeneralResponse { Message = "This The Employee is not found" };
            }

            user.VirtualCompanyId = request.VirtualCompanyId;

            // Save changes to the user object
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new GeneralResponse {Done=true, Message = "Employee added to company successfully" };
            }
            else
            {
                // Handle error if the update operation failed
                return new GeneralResponse { Message = "Failed to add employee to company" };
            }


        }

        public async Task<GeneralResponse> DeleteEmployeeFromComapanyAsync(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);



            if (user == null)
            {
                return new GeneralResponse { Message = "This The Employee is not found" };
            }

            user.VirtualCompanyId = null;

            // Save changes to the user object
            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new GeneralResponse { Done = true, Message = "Employee delete from company successfully" };
            }
            else
            {
                // Handle error if the update operation failed
                return new GeneralResponse { Message = "Failed to delete employee from company" };
            }
        }


        public async Task<EmployeesManagementGetByIdResponse> GetEmployeeByIdAsync(string employeeId)
        {
            var user = await userManager.FindByIdAsync(employeeId);

            // var response = mapper.Map<EmployeesManagementGetByIdResponse>(user);

            var response = new EmployeesManagementGetByIdResponse
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName
            };

            return response;

        }
        public async Task<IEnumerable<EmployeeManagementGetEmployeeByVirtualCompanyIdResponse>> GetEmployeeByVirtualCompanyIdAsync(int id)
        {
            var employees = await userManager.Users.Where(e => e.VirtualCompanyId == id)
                .Select(x => new EmployeeManagementGetEmployeeByVirtualCompanyIdResponse
                {
                    Id = x.Id,
                    Name = x.FullName,
                    VirtualCompanyId = x.VirtualCompanyId
                }).ToListAsync();


            return employees;

        }

    }
}
