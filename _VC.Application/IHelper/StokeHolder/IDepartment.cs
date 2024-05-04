using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.StokeHolder.Department.Add;
using _VC.Application.Services.Dto.StokeHolder.Department.AddEmpToDep;
using _VC.Application.Services.Dto.StokeHolder.Department.Update;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.IHelper.StokeHolder
{
    public interface IDepartment
    {



        // Get By Id


        //// logic

        // add employee to department
        Task<GeneralResponse> AddEmployeeToDepartemntAsync(AddEmployeeToDepartmentRequest request);



        // delete employee 
        Task<GeneralResponse> DeleteEmployeeFromDepartemntAsync(string employeeId);

        // get employee in department
        Task<IEnumerable<EmployeesManagementGetByIdResponse>> GetEmployeeFromDepartemntAsync(int departmentId);


        // assgin supervisor 
        Task<GeneralResponse> AssignEmployeeToDepartemntAsync(AddEmployeeToDepartmentRequest request);




    }
}
