using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.Add;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using _VC.Domain.Contents.Identites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServices.IStokeHolder
{
    public interface IEmployeesManagementService
    {


        // Get By id
        Task<EmployeesManagementGetByIdResponse> GetEmployeeById(string employeeId);

        // Get all by id
        Task<IEnumerable<EmployeeManagementGetEmployeeByVirtualCompanyIdResponse>> GetEmployeesByVirtualCompanyId(EmployeeManagementGetEmployeeByVirtualCompanyIdRequest dto);

        // Add Employee
        Task<GeneralResponse> AddEmployeeToComapanyService(EmployeeManagementAddRequest request);

        // Delete Employee
        Task<GeneralResponse> DeleteEmployeeFromComapanyService(string Id);


        // 

    }
}
