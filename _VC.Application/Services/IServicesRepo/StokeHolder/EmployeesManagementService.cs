using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.StokeHolder;
using _VC.Application.IHelper.VC;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.Add;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using _VC.Application.Services.IServices.IStokeHolder;
using _VC.Domain.Contents.Identites;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServicesRepo.StokeHolder
{
    public class EmployeesManagementService : IEmployeesManagementService
    {
        private readonly IVirtualCompany rep1;
        private readonly IEmployeeManagement rep2;

        public EmployeesManagementService(IVirtualCompany rep1, IEmployeeManagement rep2)
        {
            this.rep1 = rep1;
            this.rep2 = rep2;
        }
        // Get By id
       public async Task<EmployeesManagementGetByIdResponse> GetEmployeeById(string employeeId)
        {
            var response = await rep2.GetEmployeeByIdAsync(employeeId);

            return response;

        }

        // Get all by id
        public async Task<IEnumerable<EmployeeManagementGetEmployeeByVirtualCompanyIdResponse>> GetEmployeesByVirtualCompanyId(EmployeeManagementGetEmployeeByVirtualCompanyIdRequest dto)
        {
            var virtualMachineId = await rep1.returnVirtualMachineId(dto.VirtualCompanyId);

            var employees = await rep2.GetEmployeeByVirtualCompanyIdAsync(dto.VirtualCompanyId);

            foreach (var employee in employees)
            {
                employee.VirtualMachineId = virtualMachineId;
            }

            return employees;

        }

        // Add Employee

        public async Task<GeneralResponse> AddEmployeeToComapanyService(EmployeeManagementAddRequest request)
        {
           return await rep2.AddEmployeeToComapanyAsync(request);      
        }


        // Delete Employee
        public async Task<GeneralResponse> DeleteEmployeeFromComapanyService(string Id)
        {
            return await rep2.DeleteEmployeeFromComapanyAsync(Id);
        }

    }
}
