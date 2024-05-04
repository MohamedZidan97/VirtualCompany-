using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.Add;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.IHelper.StokeHolder
{
    public interface IEmployeeManagement
    {
        Task<EmployeesManagementGetByIdResponse> GetEmployeeByIdAsync (string employeeId);
        Task<IEnumerable<EmployeeManagementGetEmployeeByVirtualCompanyIdResponse>> GetEmployeeByVirtualCompanyIdAsync(int id);
        Task<GeneralResponse> AddEmployeeToComapanyAsync(EmployeeManagementAddRequest request);

        Task<GeneralResponse> DeleteEmployeeFromComapanyAsync(string Id);


    }
}